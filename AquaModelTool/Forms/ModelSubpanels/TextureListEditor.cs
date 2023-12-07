using AquaModelLibrary;
using AquaModelLibrary.AquaStructs.AquaObjectExtras;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AquaModelTool.Forms.ModelSubpanels
{
    public partial class TextureListEditor : UserControl
    {
        public AquaObject _aqp;
        private int texLimit = 0x10;
        public TextureListEditor(AquaObject aqp)
        {
            _aqp = aqp;
            InitializeComponent();
            panel1.Controls.Add(new TextureReferenceEditor(this));

            //NGS models are allowed 
            //Note for NGS textures, texUsageOrder param is seemingly more of a type. In Classic PSO2 models, it's an actual order id. Unsure of importance, but may need study
            if (_aqp.tsetList.Count > 0)
            {
                SetTsetTexLimit(aqp);
                for(int i = 0; i < aqp.tsetList.Count; i++)
                {
                    texListCB.Items.Add(i);
                }
                texListCB.SelectedIndex = 0;
                UpdateTSTAList();
            }
            else
            {
                texListCB.Enabled = false;
                texSlotCB.Enabled = false;
                addSlotButton.Enabled = false;
                removeButton.Enabled = false;
            }

        }

        public void UpdateTSTAList(int goToSlot = -1, bool doUpdateTstaEditor = true)
        {
            var currentTset = _aqp.tsetList[texListCB.SelectedIndex];
            texSlotCB.Items.Clear();
            for (int i = 0; i < currentTset.texCount; i++)
            {
                if (currentTset.tstaTexIDs[i] != -1)
                {
                    texSlotCB.Items.Add($"TSTA ({currentTset.tstaTexIDs[i]}): " + _aqp.tstaList[currentTset.tstaTexIDs[i]].texName.GetString());
                }
                else
                {
                    texSlotCB.Items.Add("TSTA -1: Null");
                }
            }

            if(doUpdateTstaEditor)
            {
                UpdateTSTAEditor();
            }

            if (goToSlot == -1)
            {
                if (texSlotCB.Items.Count > 0)
                {
                    texSlotCB.SelectedIndex = 0;
                }
            } else
            {
                texSlotCB.SelectedIndex = goToSlot;
            }
        }


        private void UpdateTSTAEditor()
        {
            ((TextureReferenceEditor)panel1.Controls[0]).UpdateTsta(_aqp.texFUnicodeNames, _aqp.texfList, _aqp.tstaList, texSlotCB.SelectedIndex >= 0 ? _aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs[texSlotCB.SelectedIndex] : -1, texSlotCB.SelectedIndex);
            panel1.Visible = true;
            panel1.Enabled = true;
        }

        private void SetTsetTexLimit(AquaObject aqp)
        {
            if (aqp.objc.type >= 0xC32 || _aqp.tsetList[0].texCount > 4)
            {
                texLimit = 0x10;
            }
            else
            {
                texLimit = 0x4;
            }
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            if(_aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs.Count < texLimit)
            {
                var texf = new AquaObject.TEXF();
                texf.texName.SetString("sampleTex_d.dds");
                _aqp.texFUnicodeNames.Add("sampleTex_d.dds");
                _aqp.texfList.Add(texf);
                _aqp.objc.texfCount++;
                var tsta = TSTATypePresets.defaultPreset;
                tsta.texName.SetString("sampleTex_d.dds");
                _aqp.tstaList.Add(tsta);
                _aqp.objc.tstaCount++;

                _aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs.Add(_aqp.tstaList.Count - 1);
                _aqp.tsetList[texListCB.SelectedIndex].texCount = _aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs.Count;

                UpdateTSTAList(texSlotCB.Items.Count);
            } else
            {
                MessageBox.Show("Cannot add beyond texture set limit!");
            }
        }

        private void insertButton_Click(object sender, System.EventArgs e)
        {
            if (_aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs.Count < texLimit)
            {
                var texf = new AquaObject.TEXF();
                texf.texName.SetString("sampleTex_d.dds");
                if(_aqp.texFUnicodeNames.Count > 0)
                {
                    _aqp.texFUnicodeNames.Add("sampleTex_d.dds");
                }
                _aqp.texfList.Add(texf);
                _aqp.objc.texfCount++;
                var tsta = TSTATypePresets.defaultPreset;
                tsta.texName.SetString("sampleTex_d.dds");
                _aqp.tstaList.Add(tsta);
                _aqp.objc.tstaCount++;

                _aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs.Insert(texSlotCB.SelectedIndex, _aqp.tstaList.Count - 1);
                _aqp.tsetList[texListCB.SelectedIndex].texCount = _aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs.Count;

                UpdateTSTAList(texSlotCB.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Cannot add beyond texture set limit!");
            }
        }

        private void removeButton_Click(object sender, System.EventArgs e)
        {
            if(_aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs.Count > 0 && _aqp.texfList.Count > 0)
            {
                var tstaId = _aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs[texSlotCB.SelectedIndex];
                var texName = _aqp.tstaList[tstaId].texName;
                int count = 0;

                //Remove tsta if unused elsewhere
                for (int i = 0; i < _aqp.tsetList.Count; i++)
                {
                    if(i == texListCB.SelectedIndex)
                    {
                        continue;
                    }
                    if(_aqp.tsetList[i].tstaTexIDs.Contains(tstaId))
                    {
                        count++;
                    }
                }
                if(count == 0)
                {
                    int id = texSlotCB.SelectedIndex;
                    _aqp.tstaList.RemoveAt(texSlotCB.SelectedIndex);
                    _aqp.objc.tstaCount--;
                    for (int i = 0; i < _aqp.tsetList.Count; i++)
                    {
                        for(int t = 0; t < _aqp.tsetList[i].tstaTexIDs.Count; t++)
                        {
                            if(_aqp.tsetList[i].tstaTexIDs[t] > id)
                            {
                                _aqp.tsetList[i].tstaTexIDs[t] = _aqp.tsetList[i].tstaTexIDs[t] - 1;
                            }
                        }
                    }
                }

                //Remove texf if unused elsewhere
                count = 0;
                for(int i = 0; i < _aqp.tstaList.Count; i++)
                {
                    var tstaName = _aqp.tstaList[i].texName;
                    if(tstaName == texName)
                    {
                        count++;
                        if(count > 1)
                        {
                            break;
                        }
                    }
                }

                if(count < 2)
                {
                    for(int i = 0; i < _aqp.texfList.Count; i++)
                    {
                        if(_aqp.texfList[i].texName == texName)
                        {
                            _aqp.texfList.RemoveAt(i);
                            if (_aqp.texFUnicodeNames.Count > 0)
                            {
                                _aqp.texFUnicodeNames.RemoveAt(i);
                            }
                            _aqp.objc.texfCount--;
                        }
                    }
                }

                _aqp.tsetList[texListCB.SelectedIndex].tstaTexIDs.RemoveAt(texSlotCB.SelectedIndex);
                _aqp.tsetList[texListCB.SelectedIndex].texCount--;

                UpdateTSTAList();
            }
        }

        private void addListButton_Click(object sender, System.EventArgs e)
        {
            var newSet = new AquaObject.TSET();
            _aqp.tsetList.Add(newSet);
            _aqp.objc.tsetCount++;
            texListCB.Items.Add(texListCB.Items.Count);
        }

        private void insertListButton_Click(object sender, System.EventArgs e)
        {
            var newSet = new AquaObject.TSET();
            _aqp.tsetList.Insert(texListCB.SelectedIndex, newSet);
            _aqp.objc.tsetCount++;
            var index = texListCB.SelectedIndex;
            texListCB.Items.Clear();
            for (int i = 0; i < _aqp.tsetList.Count; i++)
            {
                texListCB.Items.Add(i);
            }
            texListCB.SelectedIndex = index;
            UpdateTSTAList();
        }

        private void removeListButton_Click(object sender, System.EventArgs e)
        {
            int index = texListCB.SelectedIndex;
            var tset = _aqp.tsetList[index];
            _aqp.tsetList.RemoveAt(index);
            _aqp.objc.tsetCount--;
            texListCB.Items.Clear();
            for (int i = 0; i < _aqp.tsetList.Count; i++)
            {
                texListCB.Items.Add(i);
            }
            if(index >= texListCB.Items.Count)
            {
                texListCB.SelectedIndex = index - 1;
            } else if(texListCB.Items.Count > 0)
            {
                texListCB.SelectedIndex = index;
            }

            //Clean up
            RemoveOrphanedTextures(index, tset);
            UpdateTSTAList();
        }

        private void RemoveOrphanedTextures(int index, AquaObject.TSET tset)
        {
            //Get orphaned tex list
            List<int> orphanedTexIds = new List<int>(tset.tstaTexIDs);
            for (int i = 0; i < _aqp.tsetList.Count; i++)
            {
                for (int j = 0; j < orphanedTexIds.Count; j++)
                {
                    if (_aqp.tsetList[i].tstaTexIDs.Contains(orphanedTexIds[j]))
                    {
                        orphanedTexIds.RemoveAt(j);
                    }
                }
            }

            //Remove as needed while noting the new mapping
            Dictionary<int, int> idMap = new Dictionary<int, int>();
            Dictionary<string, int> orphanedTexCheck = new Dictionary<string, int>();
            int subtractionTracker = 0;
            for (int i = 0; i < _aqp.tstaList.Count; i++)
            {
                if (orphanedTexIds.Contains(i))
                {
                    subtractionTracker++;
                    var tsta = _aqp.tstaList[i];
                    _aqp.tstaList.RemoveAt(i);

                    var tstaName = tsta.texName.GetString();
                    if (orphanedTexCheck.ContainsKey(tstaName))
                    {
                        orphanedTexCheck[tstaName]++;
                    } else
                    {
                        orphanedTexCheck.Add(tstaName, 1);
                    }
                }
                if (subtractionTracker > 0)
                {
                    idMap.Add(i + subtractionTracker, i - subtractionTracker);
                }
            }

            //Texfs are typically only referenced once, so we remove them only if we don't need them.
            for(int i = 0; i < _aqp.texfList.Count; i++)
            {
                if(orphanedTexCheck.ContainsKey(_aqp.texfList[i].texName.curString) && orphanedTexCheck[_aqp.texfList[i].texName.curString] == 1)
                {
                    _aqp.texfList.RemoveAt(i);
                    if (_aqp.texFUnicodeNames.Count > 0)
                    {
                        _aqp.texFUnicodeNames.RemoveAt(i);
                    }
                    _aqp.objc.texfCount--;
                }
            }

            //Apply new mapping to tsets
            for (int i = 0; i < _aqp.tsetList.Count; i++)
            {
                foreach (var key in idMap.Keys)
                {
                    if (_aqp.tsetList[i].tstaTexIDs.Contains(key))
                    {
                        _aqp.tsetList[i].tstaTexIDs[_aqp.tsetList[i].tstaTexIDs.IndexOf(key)] = idMap[key];
                    }
                }
            }

            //Remove references and default to 0, if we have at least 1 tset, else 0
            int replacementIndex = _aqp.tsetList.Count > 0 ? 0 : -1;
            for (int i = 0; i < _aqp.meshList.Count; i++)
            {
                if (_aqp.meshList[i].tsetIndex == index)
                {
                    var mesh = _aqp.meshList[i];
                    mesh.tsetIndex = replacementIndex;
                    _aqp.meshList[i] = mesh;
                }
            }
            for (int i = 0; i < _aqp.mesh2List.Count; i++)
            {
                if (_aqp.mesh2List[i].tsetIndex == index)
                {
                    var mesh = _aqp.mesh2List[i];
                    mesh.tsetIndex = replacementIndex;
                    _aqp.mesh2List[i] = mesh;
                }
            }
        }

        private void texListCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateTSTAList();
        }

        private void texSlotCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateTSTAEditor();
        }
    }
}
