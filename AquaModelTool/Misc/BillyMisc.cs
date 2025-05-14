using AquaModelLibrary.Data.BillyHatcher;
using AquaModelLibrary.Data.BillyHatcher.ARCData;
using AquaModelLibrary.Data.Ninja;
using AquaModelLibrary.Data.Ninja.Model;
using AquaModelLibrary.Data.Ninja.Model.Ginja;
using AquaModelLibrary.Data.Ninja.Motion;
using AquaModelLibrary.Helpers.Readers;
using ArchiveLib;
using System.Numerics;

namespace AquaModelTool.Misc
{
    public class BillyMisc
    {
        public static void BillyProtoPackCompile()
        {

            var msgEgg = new MesBin(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\mes_egg_e.bin", true);
            var msgGallery = new MesBin(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\mes_gallery_e.bin", true);

            var galleryEgg = new GalleryEgg(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\gallery_egg.arc"));
            //var lib13 = new ItemLibModel(File.ReadAllBytes(@"C:\lib_model_13.arc.bak"));
            var aniHari = new AniModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ani_model_hari.arc"));
            int a = 0;
            aniHari.models[0].CountAnimated(ref a);
            var b = 0;

            var whaleModel = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\y_anic_iwhale_base.gj");
            var whaleTexList = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\y_anic_iwhale_base.gjt");
            var whaleTex = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\y_anic_iwhale_base.gvm"));

            var whaleJumpUp = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\jumpup_y_anic_iwhale_base.njm");
            var whaleJumpDown = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\jumpdown_y_anic_iwhale_base.njm");
            var whaleLand = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\landing_y_anic_iwhale_base.njm");
            var whaleRun = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\run_y_anic_iwhale_base.njm");
            var whaleSaBefore = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\sabefore_y_anic_iwhale_base.njm");
            var whaleSAttack = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\sattack_y_anic_iwhale_base.njm");
            var whaleStop = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\stop_y_anic_iwhale_base.njm");
            var whaleTakeoff = File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_animal_c1.glk_out\takeoff_y_anic_iwhale_base.njm");


            aniHari.models[0] = new NJSObject(whaleModel, NinjaVariant.Ginja, true, 0x8, 0x8);
            int animatedCount = 0;

            aniHari.models[0].CountAnimated(ref animatedCount);



            aniHari.motions[0] = new NJSMotion(whaleJumpUp, false, 0x8, false, animatedCount, 0x8);
            aniHari.motions[1] = new NJSMotion(whaleStop, false, 0x8, false, animatedCount, 0x8);
            aniHari.motions[2] = new NJSMotion(whaleStop, false, 0x8, false, animatedCount, 0x8);
            aniHari.motions[3] = new NJSMotion(whaleSAttack, false, 0x8, false, animatedCount, 0x8);
            aniHari.motions[4] = new NJSMotion(whaleJumpDown, false, 0x8, false, animatedCount, 0x8);
            aniHari.motions[5] = new NJSMotion(whaleSAttack, false, 0x8, false, animatedCount, 0x8);


            Vector3 rootPos = new Vector3(0, 10, 0);
            foreach (var motion in aniHari.motions)
            {
                if (motion.KeyDataList[0].Position.Count == 0)
                {
                    motion.KeyDataList[0].Position.Add(0, rootPos);
                    motion.KeyDataList[0].Position.Add(motion.frameCount - 1, rootPos);
                }
                else
                {
                    var keys = motion.KeyDataList[0].Position.Keys.ToArray();
                    foreach (var key in keys)
                    {
                        motion.KeyDataList[0].Position[key] += rootPos;
                    }
                }
            }


            using (MemoryStream ms = new MemoryStream(whaleTexList))
            using (BufferedStreamReaderBE<MemoryStream> sr = new BufferedStreamReaderBE<MemoryStream>(ms))
            {
                sr.Seek(8, SeekOrigin.Begin);
                sr._BEReadActive = true;
                aniHari.texList = new NJTextureList(sr, 0x8);
            }
            aniHari.gvm = whaleTex;

            File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\ani_model_hari.arc", aniHari.GetBytes());

            //ItemLibModel
            //Proto Egg Textures
            var protoEggGVM = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\aTrialData\egg.gvm"));

            //Main Egg Textures
            var amemBoot = new PRD(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\amem_boot.nrc");
            GPL gpl = null;
            for (int i = 0; i < amemBoot.fileNames.Count; i++)
            {
                if (amemBoot.fileNames[i].ToLower().EndsWith(".gpl"))
                {
                    gpl = new GPL(amemBoot.files[i]);
                }
            }

            //Richie to iwhale
            {
                var item23 = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\lib_model_23.arc"));
                item23.model = aniHari.models[0];
                item23.texList = aniHari.texList;
                item23.gvm = aniHari.gvm;
                item23.anim = aniHari.motions[1];

                var eggGVR = protoEggGVM.Entries[6].Data;
                galleryEgg.texArchives[21].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(23, eggGVR);

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_23.arc", item23.GetBytes());

                msgEgg.strings[22] = "Carileen|Linebreak|Powers of ice|Linebreak|and illusions!";
                msgGallery.strings[24] = "|Color#262320|Carileen|EndEffect|";
                msgGallery.strings[96] = "|Color#262320|Powers of ice|Linebreak|and illusions!|EndEffect|";
            }

            //Fire Comb
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_comb_fire.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 0, 19 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(20, gjt.texNames.Count - 20);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_comb_f.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_comb_fire.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_01.arc", item.GetBytes());
            }

            //Water Comb
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_comb_water.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 4, 14 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(15, gjt.texNames.Count - 15);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_comb_wa.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_comb_water.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_02.arc", item.GetBytes());
            }

            //Ice Comb
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_comb_ice.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 1, 18 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(19, gjt.texNames.Count - 19);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_comb_i.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_comb_ice.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_04.arc", item.GetBytes());
            }

            //Wind Comb
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_comb_wind.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 5, 15 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(16, gjt.texNames.Count - 16);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_comb_wi.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_comb_wind.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_05.arc", item.GetBytes());
            }

            //Iron Comb
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_comb_iron.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 2, 16 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(17, gjt.texNames.Count - 17);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_comb_ir.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                var mesh = (GinjaAttach)nj.mesh;
                var tpMeshData = mesh.transparentFaceData[0];
                tpMeshData.parameters[4].SetData(0x2500);
                tpMeshData.parameters[5].SetData(0x4211);
                mesh.opaqueFaceData.Add(tpMeshData);
                mesh.transparentFaceData.Clear();
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_comb_iron.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_06.arc", item.GetBytes());
            }

            //Light Comb
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_comb_light.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 3, 20 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(21, gjt.texNames.Count - 21);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_comb_l.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_comb_light.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_07.arc", item.GetBytes());
            }

            //Big Wings - Wings
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_wing.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 6, 19 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(20, gjt.texNames.Count - 20);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_item_bigwing.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                int counter = 0;
                nj.CountAnimated(ref counter);
                NJSMotion njm = new NJSMotion(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\item_bigwing_ge_item_bigwin.njm"), true, 0x8, false, counter, 0x8);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;
                item.anim = njm;
                var eggGVR = protoEggGVM.Entries[11].Data;
                galleryEgg.texArchives[8].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(8, eggGVR);

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_wing.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_08.arc", item.GetBytes());

            }

            //Booster
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_rocket.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 7, 8, 19 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(20, gjt.texNames.Count - 20);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_item_rocket.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                int counter = 0;
                nj.CountAnimated(ref counter);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_rocket.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_09.arc", item.GetBytes());
            }

            //Bat
            {
                var armaBat = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_bat.arc"));
                var itemBat = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_bat.arc"));
                itemBat.model = armaBat.models[0];
                itemBat.texList = armaBat.texnamesList[0];
                itemBat.gvm = armaBat.gvm;
                itemBat.anim = armaBat.motions["motions0"];
                var eggGVR = protoEggGVM.Entries[22].Data;
                galleryEgg.texArchives[0].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(18, eggGVR);

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_bat.arc", itemBat.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_18.arc", itemBat.GetBytes());
            }

            //Butterfly Large
            {
                var armaBut1 = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_butterfly_b.arc"));
                var itemBut1 = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_btfly.arc"));
                itemBut1.model = armaBut1.models[0];
                itemBut1.texList = armaBut1.texnamesList[0];
                itemBut1.gvm = armaBut1.gvm;
                itemBut1.anim = armaBut1.motions["motions0"];
                var eggGVR = protoEggGVM.Entries[47].Data;
                galleryEgg.texArchives[28].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(45, eggGVR);

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_btfly.arc", itemBut1.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_45.arc", itemBut1.GetBytes());
            }

            //Butterfly Small
            {
                var armaBut1 = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_butterfly_s.arc"));
                var itemBut1 = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_btfly2.arc"));
                itemBut1.model = armaBut1.models[0];
                itemBut1.texList = armaBut1.texnamesList[0];
                itemBut1.gvm = armaBut1.gvm;
                itemBut1.anim = armaBut1.motions["motions0"];
                var eggGVR = protoEggGVM.Entries[49].Data;
                gpl.ReplaceEntryWithGVR(47, eggGVR);

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_btfly2.arc", itemBut1.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_47.arc", itemBut1.GetBytes());
            }

            //Chameleon
            {
                var arma = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_chameleon.arc"));
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_leon.arc"));
                item.model = arma.models[0];
                item.texList = arma.texnamesList[0];
                item.gvm = arma.gvm;
                item.anim = arma.motions["motions0"];

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_leon.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_35.arc", item.GetBytes());
            }

            //Gorilla
            {
                var arma = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_gorilla.arc"));
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_gori.arc"));
                item.model = arma.models[0];
                item.texList = arma.texnamesList[0];
                item.gvm = arma.gvm;
                item.anim = arma.motions["motions0"];

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_gori.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_34.arc", item.GetBytes());
            }

            //Hawk
            {
                var arma = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_hawk.arc"));
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_hawk.arc"));
                item.model = arma.models[0];
                item.texList = arma.texnamesList[0];
                item.gvm = arma.gvm;
                item.anim = arma.motions["motions0"];

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_hawk.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_43.arc", item.GetBytes());
            }

            //Lion
            {
                var arma = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_lion.arc"));
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_lion.arc"));
                item.model = arma.models[0];
                item.texList = arma.texnamesList[0];
                item.gvm = arma.gvm;
                item.anim = arma.motions["motions0"];

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_lion.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_38.arc", item.GetBytes());
            }

            //Sheep
            {
                var arma = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_sheep.arc"));
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_sheep.arc"));
                item.model = arma.models[0];
                item.texList = arma.texnamesList[0];
                item.gvm = arma.gvm;
                item.anim = arma.motions["motions0"];

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_sheep.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_42.arc", item.GetBytes());
            }

            //Tiger
            {
                var arma = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_tiger.arc"));
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_tiger.arc"));
                item.model = arma.models[0];
                item.texList = arma.texnamesList[0];
                item.gvm = arma.gvm;
                item.anim = arma.motions["motions0"];

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_tiger.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_41.arc", item.GetBytes());
            }

            //Turtle
            {
                var arma = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_turtle.arc"));
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_turtle.arc"));
                item.model = arma.models[0];
                item.texList = arma.texnamesList[0];
                item.gvm = arma.gvm;
                item.anim = arma.motions["motions0"];

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_turtle.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_37.arc", item.GetBytes());
            }

            //Drum - Dice
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_dice.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 12, 13, 21 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(22, gjt.texNames.Count - 22);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_item_drum.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                int counter = 0;
                nj.CountAnimated(ref counter);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_dice.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_39.arc", item.GetBytes());

                msgEgg.strings[38] = "Drum|Linebreak|Drops everyone's|Linebreak|health to 1!";
                msgGallery.strings[40] = "|Color#262320|Drum|EndEffect|";
                msgGallery.strings[112] = "|Color#262320|Drops everyone's|Linebreak|health to 1!|EndEffect|";
            }

            //Pot - Super Fruit
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_maxi.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 13, 14, 23 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(24, gjt.texNames.Count - 24);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_item_pot.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                int counter = 0;
                nj.CountAnimated(ref counter);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_maxi.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_40.arc", item.GetBytes());

                msgEgg.strings[39] = "Super Watering|Linebreak|Instantly raises|Linebreak|any egg!";
                msgGallery.strings[41] = "|Color#262320|Super Watering|EndEffect|";
                msgGallery.strings[113] = "|Color#262320|Instantly raises|Linebreak|any egg!|EndEffect|";
            }

            //Clear Drink - Mouse (No old mouse and shrinking from it makes sense)
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_rat.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 10, 11, 15 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(16, gjt.texNames.Count - 16);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_item_cleardrink.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                int counter = 0;
                nj.CountAnimated(ref counter);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_rat.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_36.arc", item.GetBytes());

                msgEgg.strings[35] = "Shrink Drink|Linebreak|Shrinks you to|Linebreak|mouse-size!";
                msgGallery.strings[37] = "|Color#262320|Shrink Drink|EndEffect|";
                msgGallery.strings[109] = "|Color#262320|Shrinks you to|Linebreak|mouse-size!|EndEffect|";
            }

            //Thief - Fox
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_ani_fox.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 16, 24 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(25, gjt.texNames.Count - 25);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_item_thief.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                int counter = 0;
                nj.CountAnimated(ref counter);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_ani_fox.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_44.arc", item.GetBytes());

                msgEgg.strings[43] = "Thieves' Bag|Linebreak|Steal someone|Linebreak|else's items!";
                msgGallery.strings[45] = "|Color#262320|Thieves' Bag|EndEffect|";
                msgGallery.strings[117] = "|Color#262320|Steal someone|Linebreak|else's items!|EndEffect|";
            }

            //Heart - Heart Comb
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_cap_heart.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 17, 22 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(23, gjt.texNames.Count - 23);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_item_heart.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                int counter = 0;
                nj.CountAnimated(ref counter);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_cap_heart.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_17.arc", item.GetBytes());
            }

            //Circus Hat - Circus Cap
            {
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_cap_circus.arc"));
                var gvm = new PuyoFile(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gvm"));
                var fillerTex = gvm.Entries[20];
                List<int> retainList = new List<int>() { 9, 18 };
                ReplaceLargeTextures(gvm, fillerTex, retainList);
                NJTextureList gjt = new NJTextureList(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_item.gjt"), true, 0x8, 0x8);
                gjt.texNames.RemoveRange(19, gjt.texNames.Count - 19);
                NJSObject nj = new NJSObject(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher_\ge_p1_item.glk_out\ge_p1_comb_ci.gj"), NinjaVariant.Ginja, true, 0x8, 0x8);
                int counter = 0;
                nj.CountAnimated(ref counter);
                item.gvm = gvm;
                item.texList = gjt;
                item.model = nj;

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_cap_circus.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_15.arc", item.GetBytes());
            }

            //Crow Texture
            {
                var eggGVR = protoEggGVM.Entries[28].Data;
                //galleryEgg.texArchives[0].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(19, eggGVR);
            }

            //Pig - Life
            {
                var arma = new ArMa(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\ar_ma_pig.arc"));
                var item = new ItemLibModel(File.ReadAllBytes(@"C:\Program Files (x86)\SEGA\Billy HatcherBackup\item_extend.arc"));
                item.model = arma.models[0];
                item.texList = arma.texnamesList[0];
                item.gvm = arma.gvm;
                item.anim = arma.motions["motions0"];

                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\item_extend.arc", item.GetBytes());
                File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\lib_model_48.arc", item.GetBytes());

                var eggGVR = protoEggGVM.Entries[24].Data;
                //galleryEgg.texArchives[0].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(48, eggGVR);

                msgEgg.strings[22] = "Drum|Linebreak|Drops everyone's|Linebreak|health to 1!";
                msgGallery.strings[49] = "|Color#262320|Pig|EndEffect|";
                msgGallery.strings[121] = "|Color#262320|Receive an|Linebreak|extra life!|EndEffect|";
            }

            //Paraloop texture
            {
                var eggGVR = protoEggGVM.Entries[5].Data;
                galleryEgg.texArchives[10].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(10, eggGVR);
            }

            //Bomb texture
            {
                var eggGVR = protoEggGVM.Entries[20].Data;
                galleryEgg.texArchives[13].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(13, eggGVR);
            }

            //Motion Sensor Bomb texture
            {
                var eggGVR = protoEggGVM.Entries[21].Data;
                galleryEgg.texArchives[36].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(50, eggGVR);
            }

            //Runny texture
            {
                var eggGVR = protoEggGVM.Entries[8].Data;
                galleryEgg.texArchives[23].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(25, eggGVR);
            }

            //Biboo texture
            {
                var eggGVR = protoEggGVM.Entries[12].Data;
                galleryEgg.texArchives[22].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(33, eggGVR);
            }

            //Lion texture
            {
                var eggGVR = protoEggGVM.Entries[9].Data;
                galleryEgg.texArchives[32].Entries[0].Data = eggGVR;
                gpl.ReplaceEntryWithGVR(38, eggGVR);
            }

            //Cleanup
            for (int i = 0; i < amemBoot.fileNames.Count; i++)
            {
                if (amemBoot.fileNames[i].ToLower().EndsWith(".gpl"))
                {
                    amemBoot.files[i] = gpl.GetBytes();
                }
            }
            File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\amem_boot.nrc", amemBoot.NRCGetBytes().ToArray());
            File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\gallery_egg.arc", galleryEgg.GetBytes());

            File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\mes_egg_e.bin", msgEgg.GetBytes());
            File.WriteAllBytes(@"C:\Program Files (x86)\SEGA\Billy Hatcher\mes_gallery_e.bin", msgGallery.GetBytes());
        }

        private static void ReplaceLargeTextures(PuyoFile gvm, GenericArchive.GenericArchiveEntry fillerTex, List<int> retainList)
        {
            for (int i = 0; i < gvm.Entries.Count; i++)
            {
                if (!retainList.Contains(i))
                {
                    var entry = (GVMEntry)gvm.Entries[i];
                    entry.Data = fillerTex.Data;
                }
            }
        }
    }
}
