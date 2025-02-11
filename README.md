# Aqua-Toolset  
A series of tools primarily for Phantasy Star Online 2 and Phantasy Star Online 2: New Genesis or NGS. Also contains utilities for other games, primarily for models, textures and archives.  

Aqua Model Tool - GUI Editor for various PSO2 files with some utilities for other games.  
PSO2:  
-.aqp/.trp/.aqo/.tro editor GUI  
-.aqm/.aqc/.aqv/.aqw/.trm/.trv/.trw editor GUI  
-.bti editor GUI  
-.aqe editor GUI (Only for classic type .aqe, NGS style .aqe is very different)  
-Import Model to .aqp+.aqn  
-Import Model (e.g. .fbx with animation) to .aqm  
-Export PSO2 Model and/or animation(s) to .fbx  
-Batch convert PSO2 models to fbx  
-.prm (basic model for effects) export/import  
-PSO2 .text export/import  
-PSO2/NGS Map Model Dump  
-ConvertNATextToEnPatch - Patches PSO2 NA English client text over PSO2 JP Japanese client text given both installs  
-File Reference Sheet Generator  
    
Phantasy Star Online (PSO1):   
-PC/Xbox .xj to .fbx
-PC *n.rel (Map model) to .fbx  
-.xvm and .xvr texture conversion - Some may look incorrect, but this is due to bad initial conversions on the PC version by Sega.  
    
Phantasy Star Universe (PSU), Phantasy Star Portable (PSP), Phantasy Star Portable 2 (PSP2), Phantasy Star Portable 2 Infninity (PSP2I) - Use Tenora Works for textures and archives https://github.com/Agrathejagged/tenora-works:  
-.xnj/.unj/model .xnr to .fbx  
-.nom (Player anim) to AND from .fbx  
-.nom from PSO2 player anim (Not perfect, may need to be corrected)  
  
Phantasy Star Nova (PSN):  
-.axs model to fbx  
-.aif textures to dds  
    
Souls and Fromsoft/BluePoint Games:  
-.flver/.flv conversion to .fbx. Can take in a .dcx or bnd file and extract both the internal .flver(s) and .tpf textures  
-For .flver/.flv, can optionally convert dummies when outputting as .fbx. You may choose if these should attach to their original parents or the bones they're intended to attach to 
-For .flver/.flv dummies, the name formatting is the dummy's data separated by #s. Specifically, Dummy # reference id # parent bone name # attach bone name # flag1 # unk30 # unk34 # hex color as RGBA eg. Dummy#100#R_weapon#Model_Dmy#True#0#0#FFFFFFFF

-.cmdl/.cmsh conversion to .fbx. Files should be in their original folders as data such as materials and skeletons must be found externally in the game filesystem. Also converts .ctxr textures with the model, if they are found  
-.ctxr conversion to .dds. .ctxc textures are always connected to particular .ctxr files and do not contain enough info to convert on their own, and so are only supported via a .ctxr  
--Functional for most .flver variants, should work for all .flvers in Demon's Souls (2009) and all newer FromSoft games.   
--e.g. Demon's Souls, Dark Souls, Dark Souls 2, Bloodborne, Dark Souls 3, Elden Ring, Armored Core 6. Other Armored Core .flvers and the like have varying support.  
-bnd extract, not intended for repacking. Please use WitchyBND, Yabber, etc. for modding purposes  
-.msb map model extact - bit of a work in progress. Only extracts map piece models for now  
-Generate new .mcp/.mcg for Demon's Souls. Works partially for Dark Souls 1, needs more work there.  
-Convert model to demon's souls .flver, partly working, not super maintained right now  
-Support for unpacking and converting various Otogi 1, 2 and Metal Wolf Chaos models  
  
Other Sega Games:    
Border Break:  
-Extract models and textures. Model skinning requires bones to be transform to the bind pose via an animation, which needs more research.  
Billy Hatcher and the Giant Egg:  
-.gj to fbx. Also works on other .gj files such as for Phantasy Star Online Episode III: C.A.R.D. Revolution    
-.lnd and .mc2 to and from .fbx  
-Extraction and packing for .prd, .nrc, .gpl, and .glk archives  
-Conversion to and from Billy Hatcher .bin text (Cyrillic variant requires a matching ingame font to show ingame)  

Other Games:  
Blue Dragon:  
-.ipk/.mpk Extraction. Automatically converts .dds files to PC variants.  
Path of Exile 1/2:  
-Archive Extraction  
-Model and Animation Conversion  
-Path of Exile 1 support is shakier, but should work on most things