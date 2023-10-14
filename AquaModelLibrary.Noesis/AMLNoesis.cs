using AquaModelLibrary.AquaMethods;
using AquaModelLibrary.BluePoint.CMAT;
using Reloaded.Memory.Streams;
using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AquaModelLibrary.Noesis
{
    public unsafe class AMLNoesis
    {
        public static int NOESIS_PLUGIN_VERSION = 3;
        public static string g_pPluginName = "PSO2";
        public static string g_pPluginDesc = "Phantasy Star Online 2: New Genesis - aqp, aqo, trp, tro, prm, prx, tcb| Phantasy Star Nova - axs, aif| Phantasy Star Universe .xnj, .xnr (model)| Demon's Souls (2020) .cmsh| plugin by Shadowth117";
        public static GCHandle dataCheckHandle;
        public static GCHandle dataLoadHandle;
        public static List<GCHandle> handles = new List<GCHandle>();
        public delegate bool AquaModelCheck(byte* fileBuffer, nint bufferLen, noeRAPI_s* rapi);
        public delegate IntPtr AquaModelLoad(byte* fileBuffer, nint bufferLen, ref int numMdl, noeRAPI_s* rapi);
        public static AquaModelCheck AquaModelCheckDel;
        public static AquaModelLoad AquaModelLoadDel;
        public static NoesisFunctions api;

        //=========================================
        //Main Noesis interface
        //=========================================

        //called by Noesis to init the plugin
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) }, EntryPoint = "NPAPI_Init")]
        public static bool NPAPI_Init(mathImpFn_s* mathfn, noePluginFn_s* noepfn)
        {
            File.WriteAllBytes($"C:\\noesisMaterial_s size {sizeof(noesisMaterial_s)} {sizeof(noesisMaterial_s):X}", new byte[0]);
            File.WriteAllBytes($"C:\\noesisExtTexRef_s size {sizeof(noesisExtTexRef_s)} {sizeof(noesisExtTexRef_s):X}", new byte[0]);
            File.WriteAllBytes($"C:\\noesisMatExpr_s size {sizeof(noesisMatExpr_s)} {sizeof(noesisMatExpr_s):X}", new byte[0]);
            File.WriteAllBytes($"C:\\noesisMatEx_s size {sizeof(noesisMatEx_s)} {sizeof(noesisMatEx_s):X}", new byte[0]);

            File.WriteAllBytes($"C:\\noesisTex_s size {sizeof(noesisTex_s)} {sizeof(noesisTex_s):X}", new byte[0]);
            File.WriteAllBytes($"C:\\noesisTexFr_s size {sizeof(noesisTexFr_s)} {sizeof(noesisTexFr_s):X}", new byte[0]);
            File.WriteAllBytes($"C:\\SNoeHDRTexData size {sizeof(SNoeHDRTexData)} {sizeof(SNoeHDRTexData):X}", new byte[0]);
            File.WriteAllBytes($"C:\\SNoePalData size {sizeof(SNoePalData)} {sizeof(SNoePalData):X}", new byte[0]);
            File.WriteAllBytes($"C:\\SNoeTexExtraData size {sizeof(SNoeTexExtraData)} {sizeof(SNoeTexExtraData):X}", new byte[0]);
            api = new NoesisFunctions(mathfn, noepfn);

            //Descriptions
            var descPSO2 = Encoding.UTF8.GetBytes("PSO2 model\0");
            var descPSO2Simple = Encoding.UTF8.GetBytes("PSO2 simple model\0");

            //Types
            var typesPSO2 = Encoding.UTF8.GetBytes(".aqp;.aqo;.trp;.tro\0");
            var typesPSO2Simple = Encoding.UTF8.GetBytes(".prm;.prx\0");

            AquaModelCheckDel = AquaModelCheckFn;
            //dataCheckHandle = GCHandle.Alloc(AquaModelCheckDel, GCHandleType.Pinned);
            
            AquaModelLoadDel = AquaModelLoadFn;
            //dataLoadHandle = GCHandle.Alloc(AquaModelLoadDel, GCHandleType.Pinned);

            //pso2 and ngs models
            var fh = api.npAPI_Register(descPSO2, typesPSO2);

            if (fh < 0)
            {
                return false;
            }
            //set the data handlers for this format
            api.nPAPI_SetTypeHandler_TypeCheck(fh, Marshal.GetFunctionPointerForDelegate(AquaModelCheckDel));

            api.nPAPI_SetTypeHandler_LoadModel(fh, Marshal.GetFunctionPointerForDelegate(AquaModelLoadDel));

            return true;
        }

        //called by Noesis before the plugin is freed
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) }, EntryPoint = "NPAPI_Shutdown")]
        public static void NPAPI_Shutdown()
        {
            foreach(var handle in handles)
            {
                handle.Free();
            }
            handles.Clear();
            //File.WriteAllBytes("C:\\shutdown.bin", new byte[0]);
            return;
        }

        //returns current version
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) }, EntryPoint = "NPAPI_GetPluginVer")]
        public static int NPAPI_GetPluginVer()
        {
            //File.WriteAllBytes("C:\\GetPlugVer.bin", new byte[0]);
            return NOESIS_PLUGIN_VERSION;
        }

        //copies off plugin info strings
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) }, EntryPoint = "NPAPI_GetPluginInfo")]
        public static bool NPAPI_GetPluginInfo(noePluginInfo_s* infOut)
        {
            StringCopy(g_pPluginName, 64, infOut->pluginName);
            StringCopy(g_pPluginDesc, 512, infOut->pluginDesc);

            //File.WriteAllBytes("C:\\GetPlugInfo.bin", new byte[0]);
            return true;
        }

        public static bool DummyMethod(byte* fileBuffer, nint bufferLen, noeRAPI_s* rapi)
        {
            return true;
        }

        public static bool AquaModelCheckFn(byte* fileBuffer, nint bufferLen, noeRAPI_s* rapi)
        {
            File.WriteAllBytes("C:\\InCheck.bin", new byte[0]);
            RAPIObj rapiObj = new RAPIObj(rapi);
            string filename = GetWideCharString(rapiObj.noesis_GetInputNameW());

            using (Stream stream = new UnmanagedMemoryStream(fileBuffer, bufferLen))
            using (var streamReader = new BufferedStreamReader(stream, 8192))
            {
                var result = AquaGeneralMethods.ReadAquaHeader(streamReader, Path.GetExtension(filename), out int offset);

                File.WriteAllBytes("C:\\CheckResultObtained.bin", new byte[0]);
                if (result == "NIFL" || result == "VTBF")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static IntPtr AquaModelLoadFn(byte* fileBuffer, nint bufferLen, ref int numMdl, noeRAPI_s* rapi)
        {
            bool isPso2Model = true;
            RAPIObj rapiObj = new RAPIObj(rapi);
            IntPtr ctx = rapiObj.rpgCreateContext();
            noesisMaterial_s[] matArr = null;
            IntPtr matNoesisArray = api.array_Alloc(sizeof(noesisMaterial_s), 4096);
            List<int> matIdTemp = new List<int>();
            noesisTex_s[] texArr = null;
            noesisTex_s[] texArrFinal = null;
            IntPtr texNoesisArray = api.array_Alloc(sizeof(noesisTex_s), 4096);
            Dictionary<int, int> texSuccessDict = new Dictionary<int, int>();
            noesisMaterial_s* matArrAdd = null;
            noesisTex_s* texArrAdd = null;
            List<string> texNames = new List<string>();
            AquaNode aqn = null;
            string filename = GetWideCharString(rapiObj.noesis_GetInputNameW());
            string aqnFilename = "";

            modelBone_s* bones = null;

            switch (Path.GetExtension(filename))
            {
                case ".aqp":
                case ".aqo":
                    aqnFilename = Path.ChangeExtension(filename, ".aqn");
                    break;
                case ".trp":
                case ".tro":
                    aqnFilename = Path.ChangeExtension(filename, ".trn");
                    break;
            }
            File.WriteAllBytes("C:\\FileName Ext Switched.bin", Encoding.UTF8.GetBytes(aqnFilename));
            AquaUtil aquaUtil = new AquaUtil();

            byte[] fileArr = new byte[bufferLen];
            Marshal.Copy((nint)fileBuffer, fileArr, 0, (int)bufferLen);
            var fileList = new List<byte>(fileArr);
            aquaUtil.BeginReadModel(fileList.ToArray());
            File.WriteAllBytes("C:\\Model read.bin", new byte[0]);

            //Adjust model to be only 1 material per vertex set for NGS models and adjust Material type to match shading handling
            var model = aquaUtil.aquaModels[0].models[0];
            if (model.objc.type > 0xC32)
            {
                model.splitVSETPerMesh();
            }
            model.FixHollowMatNaming();

            //Handle bones if they exist
            bool setBoneData = false;
            if (File.Exists(aqnFilename))
            {
                setBoneData = true;
                aquaUtil.ReadBones(aqnFilename);
                File.WriteAllBytes("C:\\bones read.bin", new byte[0]);

                aqn = aquaUtil.aquaBones[0];
                bones = rapiObj.noesis_AllocBones(aqn.nodeList.Count);
                File.WriteAllBytes("C:\\bones alloced.bin", new byte[0]);

                //If names aren't unique (should only happen in a mod, but legal ingame afaik), note to add ids into name
                List<string> strings = new List<string>();
                bool addId = false;
                foreach (var b in aqn.nodeList)
                {
                    if (strings.IndexOf(b.boneName.GetString()) > -1)
                    {
                        addId = true;
                        break;
                    }
                }

                for (int i = 0; i < aqn.nodeList.Count; i++)
                {
                    var aqBone = aqn.nodeList[i];
                    var boneMat = aqBone.GetInverseBindPoseMatrixInverted();
                    modelBone_s bone = new modelBone_s();
                    bone.mat = new modelMatrix_s() { x1 = new Vector3(boneMat.M11, boneMat.M12, boneMat.M13), x2 = new Vector3(boneMat.M21, boneMat.M22, boneMat.M23), x3 = new Vector3(boneMat.M31, boneMat.M32, boneMat.M33), o = new Vector3(boneMat.M41, boneMat.M42, boneMat.M43) };
                    bone.eData.parent = aqBone.parentId == -1 ? 0 : (nint)bones + (sizeof(modelBone_s) * aqBone.parentId);

                    //Set up name
                    var name = new byte[128];
                    var boneNameStr = aqBone.boneName.GetString();
                    StringCopy(boneNameStr, boneNameStr.Length, name);
                    var idStr = Encoding.UTF8.GetBytes($"({i})_");
                    if (addId)
                    {
                        for (int j = 0; j < idStr.Length; j++)
                        {
                            bone.name[j] = idStr[j];
                        }
                    }
                    for (int j = 0; j < name.Length; j++)
                    {
                        bone.name[j + idStr.Length] = name[j];
                    }

                    bones[i] = bone;
                }
            }
            File.WriteAllBytes("C:\\bones handled.bin", new byte[0]);

            //Set up materials
            var materials = model.GetUniqueMaterials(out List<int> meshMatMapping);
            matArr = new noesisMaterial_s[materials.Count];
            for (int i = 0; i < materials.Count; i++)
            {
                var aqMat = materials[i];

                File.WriteAllBytes($"C:\\material {i} start.bin", new byte[0]);
                var mat = rapiObj.noesis_GetMaterialList(1, true);

                byte[] matName = new byte[100];
                StringCopy(aqMat.matName, aqMat.matName.Length, matName);
                mat->name = rapiObj.noesis_PooledString(matName);

                //Don't overload this if the ngs hair ones comes into play
                mat->diffuse = aqMat.diffuseRGBA.Length() > 2 ? new Vector4(1, 1, 1, 1) : aqMat.diffuseRGBA;
                mat->specular = aqMat.unkRGBA0;
                mat->blendSrc = aqMat.srcAlpha;
                mat->blendDst = aqMat.destAlpha;

                //Handle player texture assignments
                if (aqMat.texNames.Count > 0 && aqMat.texNames[0].EndsWith("_diffuse.dds") && isPso2Model)
                {
                    var dir = Path.GetDirectoryName(filename);
                    var texFiles = Directory.GetFiles(dir, ".dds");
                    foreach (var texFile in texFiles)
                    {
                        if (texFile.EndsWith("_d.dds"))
                        {
                            aqMat.texNames[0] = Path.GetFileName(texFile);
                            break;
                        }
                    }
                    File.WriteAllBytes($"C:\\material {i} player tex reassigned.bin", new byte[0]);
                }

                File.WriteAllBytes($"C:\\material {i} index preassignment is {mat->texIdx}.bin", new byte[0]);
                //Add to texture list if new
                if (!texNames.Contains(aqMat.texNames[0]))
                {
                    matIdTemp.Add(texNames.Count);
                    texNames.Add(aqMat.texNames[0]);
                }
                else
                {
                    matIdTemp.Add(texNames.IndexOf(aqMat.texNames[0]));
                }

                mat->noDefaultBlend = true;
                matArr[i] = Marshal.PtrToStructure<noesisMaterial_s>((nint)mat);
                api.array_Append(matNoesisArray, (nint)mat);
                if (matArr.Length == 1)
                {
                    matArrAdd = mat;
                }
            }

            //Set up textures
            texArr = new noesisTex_s[texNames.Count];
            int validTexCounter = 0;
            for (int i = 0; i < texNames.Count; i++)
            {
                File.WriteAllBytes($"C:\\Attempting to read {texNames[i]}.bin", new byte[0]);
                noesisTex_s* tex = (noesisTex_s*)0;
                var texPath = Path.Combine(Path.GetDirectoryName(filename),texNames[i]);
                if (File.Exists(texPath))
                {
                    var texBytes = File.ReadAllBytes(texPath);
                    File.WriteAllBytes($"C:\\tex {texNames[i]} read.bin", new byte[i]);
                    IntPtr texBuffer = rapiObj.noesis_PooledAlloc((nuint)texBytes.Length);
                    File.WriteAllBytes($"C:\\tex {texNames[i]} pooled alloc.bin", new byte[i]);
                    Marshal.Copy(texBytes, 0, texBuffer, texBytes.Length);
                    File.WriteAllBytes($"C:\\tex {texNames[i]} marshaled.bin", new byte[i]);
                    tex = rapiObj.noesis_LoadTexByHandler((byte*)texBuffer, texBytes.Length, Encoding.UTF8.GetBytes(".dds"));
                    File.WriteAllBytes($"C:\\tex {texNames[i]} loaded.bin", new byte[i]);
                    byte[] texFilenameBytes = new byte[4096];
                    StringCopy(texPath, texPath.Length, texFilenameBytes);
                    tex->filename = rapiObj.noesis_PooledString(texFilenameBytes);
                    File.WriteAllBytes($"C:\\tex {texNames[i]} filename pooled.bin", new byte[i]);
                    texArr[i] = Marshal.PtrToStructure<noesisTex_s>((nint)tex);

                    if (texArr.Length == 1)
                    {
                        texArrAdd = tex;
                    }
                    texSuccessDict.Add(i, validTexCounter);
                    validTexCounter++;
                    api.array_Append(texNoesisArray, (nint)tex);
                }
            }
            var successfulTextureIds = texSuccessDict.Keys.ToList();
            successfulTextureIds.Sort();
            texArrFinal = new noesisTex_s[validTexCounter];

            foreach (var id in successfulTextureIds)
            {
                texArrFinal[texSuccessDict[id]] = texArr[id];
                //api.array_Append(texNoesisArray, (nint)(texArr[id]));
            }

            for(int i = 0; i < matArr.Length; i++)
            {
                var mat = matArr[i];
                var aqMat = materials[i];

                if (texSuccessDict.ContainsKey(matIdTemp[i]))
                {
                    mat.texIdx = texSuccessDict[matIdTemp[i]];
                    /*
                    mat.alphaTest = (float)aqMat.alphaCutoff / 255;
                    if (mat.alphaTest > 1)
                    {
                        mat.alphaTest = 1;
                    }
                    */
                }

                matArr[i] = mat;
            }

            File.WriteAllBytes($"C:\\main mat loop done.bin", new byte[0]);
            if (materials.Count > 0)
            {
                File.WriteAllBytes($"C:\\Attempting to bind mats. mat arr len = {matArr.Length}, texArrLen = {texArrFinal.Length} .bin", new byte[0]);
                var arr2 = new noesisMaterial_s[] { matArr[0] };
                var matCArrList = new CArrayList() { m_array = matNoesisArray };
                var texCArrList = new CArrayList() { m_array = texNoesisArray };
                IntPtr matCArrPtr = new nint();
                IntPtr texCArrPtr = new nint();
                Marshal.StructureToPtr(matCArrList, matCArrPtr, false);
                Marshal.StructureToPtr(texCArrList, texCArrPtr, false);
                //noesisMatData_s* md = rapiObj.noesis_GetMatData(arr2, arr2.Length, texArr, texArrFinal.Length);
                //noesisMatData_s* md = rapiObj.noesis_GetMatData(matArr, matArr.Length, texArr, texArrFinal.Length);
                noesisMatData_s* md = rapiObj.noesis_GetMatDataFromLists(matCArrPtr, texCArrPtr);
                //noesisMatData_s* md = rapiObj.noesis_GetMatData(matArr, matArr.Length, texArrFinal, texArrFinal.Length);
                //noesisMatData_s* md = rapiObj.noesis_GetMatDataFromLists(ref matNoesisArray, ref texNoesisArray);
                File.WriteAllBytes($"C:\\mat wrapup 1 done.bin", new byte[0]);
                rapiObj.rpgSetExData_Materials(md);
                File.WriteAllBytes($"C:\\mat wrapup 2 done.bin", new byte[0]);
            }

            //This has to be set down here or Noesis freaks out
            if (setBoneData)
            {
#pragma warning disable CS8602
                rapiObj.rpgSetExData_Bones(bones, aqn.nodeList.Count);
#pragma warning restore CS8602
                File.WriteAllBytes($"C:\\bone wrapup done.bin", new byte[0]);
            }

            //Handle mesh data
            for (int i = 0; i < model.meshList.Count; i++)
            {
                var mesh = model.meshList[i];
                var vtxl = model.vtxlList[mesh.vsetIndex];
                var faces = model.strips[mesh.psetIndex];
                File.WriteAllBytes($"C:\\setting material index {i}.bin", new byte[0]);
                rapiObj.rpgSetMaterialIndex(i);

                int[] bonePalette;
                File.WriteAllBytes($"C:\\BonePalette setup {i}.bin", new byte[0]);
                if (model.objc.bonePaletteOffset > 0)
                {
                    bonePalette = new int[model.bonePalette.Count];
                    for (int j = 0; j < model.bonePalette.Count; j++)
                    {
                        bonePalette[j] = (int)model.bonePalette[j];
                    }
                }
                else
                {
                    bonePalette = new int[vtxl.bonePalette.Count];
                    for (int bn = 0; bn < vtxl.bonePalette.Count; bn++)
                    {
                        bonePalette[bn] = vtxl.bonePalette[bn];
                    }
                }
                File.WriteAllBytes($"C:\\SetBoneMap {i}.bin", new byte[0]);
                rapiObj.rpgSetBoneMap(bonePalette);

                File.WriteAllBytes($"C:\\Start binding vert data {i}.bin", new byte[0]);
                if (vtxl.vertPositions.Count > 0)
                {
                    List<byte> posList = new List<byte>();
                    foreach (var pos in vtxl.vertPositions) { posList.AddRange(Reloaded.Memory.Struct.GetBytes(pos)); }
                    rapiObj.rpgBindPositionBuffer(posList.ToArray(), rpgeoDataType_e.RPGEODATA_FLOAT, 0xC);
                    File.WriteAllBytes($"C:\\Position set {i}.bin", new byte[0]);
                }
                if (vtxl.vertNormals.Count > 0)
                {
                    List<byte> nrmList = new List<byte>();
                    foreach (var nrm in vtxl.vertNormals) { nrmList.AddRange(Reloaded.Memory.Struct.GetBytes(nrm)); }
                    File.WriteAllBytes($"C:\\Normal start setting {i}.bin", new byte[0]);
                    rapiObj.rpgBindNormalBuffer(nrmList.ToArray(), rpgeoDataType_e.RPGEODATA_FLOAT, 0xC);
                    File.WriteAllBytes($"C:\\Normal set {i}.bin", new byte[0]);
                }
                if (vtxl.vertColors.Count > 0)
                {
                    List<byte> vertColorsList = new List<byte>();
                    File.WriteAllBytes($"C:\\Color .NET array set {i}.bin", new byte[0]);
                    foreach (var color in vtxl.vertColors) { vertColorsList.Add(color[2]); vertColorsList.Add(color[1]); vertColorsList.Add(color[0]); vertColorsList.Add(color[3]); }
                    File.WriteAllBytes($"C:\\Color start setting {i}.bin", new byte[0]);
                    rapiObj.rpgBindColorBuffer(vertColorsList.ToArray(), rpgeoDataType_e.RPGEODATA_UBYTE, 4, 4);
                    File.WriteAllBytes($"C:\\Colors set {i}.bin", new byte[0]);
                }
                if (vtxl.uv1List.Count > 0)
                {
                    List<byte> uvList = new List<byte>();
                    foreach (var uv in vtxl.uv1List) { uvList.AddRange(Reloaded.Memory.Struct.GetBytes(uv)); }
                    rapiObj.rpgBindUV1Buffer(uvList.ToArray(), rpgeoDataType_e.RPGEODATA_FLOAT, 8);
                    File.WriteAllBytes($"C:\\UV1 set {i}.bin", new byte[0]);
                }
                if (vtxl.uv2List.Count > 0)
                {
                    List<byte> uvList = new List<byte>();
                    foreach (var uv in vtxl.uv1List) { uvList.AddRange(Reloaded.Memory.Struct.GetBytes(uv)); }
                    rapiObj.rpgBindUV2Buffer(uvList.ToArray(), rpgeoDataType_e.RPGEODATA_FLOAT, 8);
                    File.WriteAllBytes($"C:\\UV2set {i}.bin", new byte[0]);
                }
                if (vtxl.uv3List.Count > 0)
                {
                    List<byte> uvList = new List<byte>();
                    foreach (var uv in vtxl.uv1List) { uvList.AddRange(Reloaded.Memory.Struct.GetBytes(uv)); }
                    rapiObj.rpgBindUVXBuffer(uvList.ToArray(), rpgeoDataType_e.RPGEODATA_FLOAT, 8, 2, 2);
                    File.WriteAllBytes($"C:\\UV3 set {i}.bin", new byte[0]);
                }
                if (vtxl.uv4List.Count > 0)
                {
                    List<byte> uvList = new List<byte>();
                    foreach (var uv in vtxl.uv1List) { uvList.AddRange(Reloaded.Memory.Struct.GetBytes(uv)); }
                    rapiObj.rpgBindUVXBuffer(uvList.ToArray(), rpgeoDataType_e.RPGEODATA_FLOAT, 8, 3, 2);
                    File.WriteAllBytes($"C:\\UV4 set {i}.bin", new byte[0]);
                }
                if (vtxl.vert0x22.Count > 0)
                {
                    List<byte> vert0x22s = new List<byte>();
                    foreach (var x22s in vtxl.vert0x22) { vert0x22s.AddRange(BitConverter.GetBytes(x22s[0])); vert0x22s.AddRange(BitConverter.GetBytes(x22s[1])); }
                    rapiObj.rpgBindUVXBuffer(vert0x22s.ToArray(), rpgeoDataType_e.RPGEODATA_SHORT, 4, 4, 2);
                    File.WriteAllBytes($"C:\\0x22 set {i}.bin", new byte[0]);
                }
                if (vtxl.vert0x23.Count > 0)
                {
                    List<byte> vert0x23s = new List<byte>();
                    foreach (var x23s in vtxl.vert0x23) { vert0x23s.AddRange(BitConverter.GetBytes(x23s[0])); vert0x23s.AddRange(BitConverter.GetBytes(x23s[1])); }
                    rapiObj.rpgBindUVXBuffer(vert0x23s.ToArray(), rpgeoDataType_e.RPGEODATA_SHORT, 4, 5, 2);
                    File.WriteAllBytes($"C:\\0x23 set {i}.bin", new byte[0]);
                }
                if (vtxl.vert0x24.Count > 0)
                {
                    List<byte> vert0x24s = new List<byte>();
                    foreach (var x24s in vtxl.vert0x24) { vert0x24s.AddRange(BitConverter.GetBytes(x24s[0])); vert0x24s.AddRange(BitConverter.GetBytes(x24s[1])); }
                    rapiObj.rpgBindUVXBuffer(vert0x24s.ToArray(), rpgeoDataType_e.RPGEODATA_SHORT, 4, 6, 2);
                    File.WriteAllBytes($"C:\\0x24 set {i}.bin", new byte[0]);
                }
                if (vtxl.vert0x25.Count > 0)
                {
                    List<byte> vert0x25s = new List<byte>();
                    foreach (var x25s in vtxl.vert0x25) { vert0x25s.AddRange(BitConverter.GetBytes(x25s[0])); vert0x25s.AddRange(BitConverter.GetBytes(x25s[1])); }
                    rapiObj.rpgBindUVXBuffer(vert0x25s.ToArray(), rpgeoDataType_e.RPGEODATA_SHORT, 4, 7, 2);
                    File.WriteAllBytes($"C:\\0x25 set {i}.bin", new byte[0]);
                }
                if (vtxl.vertColor2s.Count > 0)
                {
                    List<byte> vertColor2sList = new List<byte>();
                    foreach (var color in vtxl.vertColors) { vertColor2sList.Add(color[2]); vertColor2sList.Add(color[1]); vertColor2sList.Add(color[0]); vertColor2sList.Add(color[3]); }
                    rapiObj.rpgBindUVXBuffer(vertColor2sList.ToArray(), rpgeoDataType_e.RPGEODATA_UBYTE, 4, 8, 4);
                    File.WriteAllBytes($"C:\\Vert Color 2 set {i}.bin", new byte[0]);
                }
                if (vtxl.trueVertWeights.Count > 0)
                {
                    List<byte> vertWeights = new List<byte>();
                    foreach (var weightInds in vtxl.trueVertWeightIndices) { vertWeights.AddRange(BitConverter.GetBytes(weightInds[0])); vertWeights.AddRange(BitConverter.GetBytes(weightInds[1])); vertWeights.AddRange(BitConverter.GetBytes(weightInds[2])); vertWeights.AddRange(BitConverter.GetBytes(weightInds[3])); }
                    rapiObj.rpgBindBoneWeightBuffer(vertWeights.ToArray(), rpgeoDataType_e.RPGEODATA_FLOAT, 0x10, 4);
                    File.WriteAllBytes($"C:\\Weight set {i}.bin", new byte[0]);
                }
                if (vtxl.trueVertWeightIndices.Count > 0)
                {
                    List<byte> vertWeightIndices = new List<byte>();
                    foreach (var weightInds in vtxl.trueVertWeightIndices) { vertWeightIndices.AddRange(BitConverter.GetBytes(weightInds[0])); vertWeightIndices.AddRange(BitConverter.GetBytes(weightInds[1])); vertWeightIndices.AddRange(BitConverter.GetBytes(weightInds[2])); vertWeightIndices.AddRange(BitConverter.GetBytes(weightInds[3])); }
                    rapiObj.rpgBindBoneIndexBuffer(vertWeightIndices.ToArray(), rpgeoDataType_e.RPGEODATA_INT, 4, 4);
                    File.WriteAllBytes($"C:\\Weight Index set {i}.bin", new byte[0]);
                }

                var meshTris = faces.GetTriangles();
                List<byte> tris = new List<byte>();
                foreach (var tri in meshTris) { tris.AddRange(BitConverter.GetBytes((int)tri.X)); tris.AddRange(BitConverter.GetBytes((int)tri.Y)); tris.AddRange(BitConverter.GetBytes((int)tri.Z)); }
                File.WriteAllBytes($"C:\\Start setting triangles {i}.bin", new byte[0]);
                rapiObj.rpgCommitTriangles(tris.ToArray(), rpgeoDataType_e.RPGEODATA_INT, meshTris.Count, rpgeoPrimType_e.RPGEO_TRIANGLE_STRIP, true);
                File.WriteAllBytes($"C:\\Triangles committed {i}.bin", new byte[0]);
                rapiObj.rpgClearBufferBinds();
                File.WriteAllBytes($"C:\\Clear Buffer Binds {i}.bin", new byte[0]);

                if (bonePalette.Length > 0)
                {
                    File.WriteAllBytes($"C:\\Setting bone map to null {i}.bin", new byte[0]);
                    rapiObj.rpgSetBoneMap(null);
                    File.WriteAllBytes($"C:\\Bone Map set to null {i}.bin", new byte[0]);
                }
            }

            File.WriteAllBytes($"C:\\Constructing model.bin", new byte[0]);
            IntPtr mdl = rapiObj.rpgConstructModel();

            File.WriteAllBytes($"C:\\Model contructed.bin", new byte[0]);
            numMdl = 1;
            rapiObj.rpgDestroyContext(ctx);
            File.WriteAllBytes($"C:\\Context Destroyed.bin", new byte[0]);
            api.array_Free(texNoesisArray);
            api.array_Free(matNoesisArray);

            return mdl;
        }

        private static string GetWideCharString(byte* rawFname)
        {
            return Marshal.PtrToStringUni((IntPtr)rawFname);
        }

        public static void StringCopy(string str, int count, byte* strLocation)
        {
            byte[] strArr = Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < count; i++)
            {
                if (i < strArr.Length)
                {
                    strLocation[i] = strArr[i];
                }
                else
                {
                    strLocation[i] = 0;
                }
            }
        }

        public static void StringCopy(string str, int count, byte[] strLocation)
        {
            byte[] strArr = Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < count; i++)
            {
                if (i < strArr.Length)
                {
                    strLocation[i] = strArr[i];
                }
                else
                {
                    strLocation[i] = 0;
                }
            }
        }
    }
}