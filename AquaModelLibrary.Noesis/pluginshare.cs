using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static AquaModelLibrary.Noesis.NoesisFunctions;
using static AquaModelLibrary.Noesis.RAPIObj;
using static System.Net.Mime.MediaTypeNames;

namespace AquaModelLibrary.Noesis
{
    public unsafe class NoesisFunctions
    {
        public delegate int NPAPI_Register(byte[] typeDesc, byte[] extList);
        public delegate void NPAPI_SetTypeHandler_TypeCheck(int th, IntPtr dataCheck); //datacheck is defined as public IntPtr dataCheck)(BYTE *fileBuffer, int bufferLen, noeRAPI_t *rapi)
        public delegate void NPAPI_SetTypeHandler_LoadModel(int th, IntPtr loadModel); //loadModel is defined as noesisModel_t *(*loadModel)(BYTE *fileBuffer, int bufferLen, int &numMdl, noeRAPI_t *rapi)
        public delegate int NPAPI_GetAPIVersion();
        public delegate void Math_CalcPlaneEq(float* x, float* y, float* z, float* planeEq);
        public delegate IntPtr Array_Alloc(int elementSize, int initialNum); //Returns a cntArray_t
        public delegate void Array_Free(IntPtr ar); //cntArray_t is the ar IntPtr in these
	    public delegate void Array_SetGrowth (IntPtr ar, bool exponential);
        public delegate IntPtr Array_GetElement(IntPtr ar, int index);
        public delegate IntPtr Array_GetElementGrow(IntPtr ar, int index);
	    public delegate void Array_Append(IntPtr ar, IntPtr element);
        public delegate void Array_RemoveLast(IntPtr ar);
	    public delegate void Array_Insert(IntPtr ar, IntPtr element, int index);
        public delegate void Array_Remove(IntPtr ar, int index);
	    public delegate int Array_GetCount(IntPtr ar);
	    public delegate void Array_Reset(IntPtr ar);
	    public delegate void Array_Tighten(IntPtr ar);

        public NPAPI_Register npAPI_Register;
        public NPAPI_SetTypeHandler_TypeCheck nPAPI_SetTypeHandler_TypeCheck;
        public NPAPI_SetTypeHandler_LoadModel nPAPI_SetTypeHandler_LoadModel;
        public NPAPI_GetAPIVersion nPAPI_GetAPIVersion;
        public Math_CalcPlaneEq math_CalcPlaneEq;
        public Array_Alloc array_Alloc; //Returns a cntArray_t
        public Array_Free array_Free; //cntArray_t is the ar IntPtr in these
        public Array_SetGrowth array_SetGrowth;
        public Array_GetElement array_GetElement;
        public Array_GetElementGrow array_GetElementGrow;
        public Array_Append array_Append;
        public Array_RemoveLast array_RemoveLast;
        public Array_Insert array_Insert;
        public Array_Remove array_Remove;
        public Array_GetCount array_GetCount;
        public Array_Reset array_Reset;
        public Array_Tighten array_Tighten;
        public NoesisFunctions(mathImpFn_s* mathStr, noePluginFn_s* noeStr)
        {
            npAPI_Register = Marshal.GetDelegateForFunctionPointer<NPAPI_Register>(noeStr->NPAPI_Register);
            nPAPI_SetTypeHandler_TypeCheck = Marshal.GetDelegateForFunctionPointer<NPAPI_SetTypeHandler_TypeCheck>(noeStr->NPAPI_SetTypeHandler_TypeCheck);
            nPAPI_SetTypeHandler_LoadModel = Marshal.GetDelegateForFunctionPointer<NPAPI_SetTypeHandler_LoadModel>(noeStr->NPAPI_SetTypeHandler_LoadModel);
            nPAPI_GetAPIVersion = Marshal.GetDelegateForFunctionPointer<NPAPI_GetAPIVersion>(noeStr->NPAPI_GetAPIVersion);
            math_CalcPlaneEq = Marshal.GetDelegateForFunctionPointer<Math_CalcPlaneEq>(mathStr->Math_CalcPlaneEq);

            array_Alloc = Marshal.GetDelegateForFunctionPointer<Array_Alloc>(noeStr->Array_Alloc);
            array_Free = Marshal.GetDelegateForFunctionPointer<Array_Free>(noeStr->Array_Free);
            array_SetGrowth = Marshal.GetDelegateForFunctionPointer<Array_SetGrowth>(noeStr->Array_SetGrowth);
            array_GetElement = Marshal.GetDelegateForFunctionPointer<Array_GetElement>(noeStr->Array_GetElement);
            array_GetElementGrow = Marshal.GetDelegateForFunctionPointer<Array_GetElementGrow>(noeStr->Array_GetElementGrow);
            array_Append = Marshal.GetDelegateForFunctionPointer<Array_Append>(noeStr->Array_Append);
            array_RemoveLast = Marshal.GetDelegateForFunctionPointer<Array_RemoveLast>(noeStr->Array_RemoveLast);
            array_Insert = Marshal.GetDelegateForFunctionPointer<Array_Insert>(noeStr->Array_Insert);
            array_Remove = Marshal.GetDelegateForFunctionPointer<Array_Remove>(noeStr->Array_Remove);
            array_GetCount = Marshal.GetDelegateForFunctionPointer<Array_GetCount>(noeStr->Array_GetCount);
            array_Reset = Marshal.GetDelegateForFunctionPointer<Array_Reset>(noeStr->Array_Reset);
            array_Tighten = Marshal.GetDelegateForFunctionPointer<Array_Tighten>(noeStr->Array_Tighten);
        }
    }

    public unsafe class RAPIObj
    {
        public delegate IntPtr RpgCreateContext();
        public delegate void RpgDestroyContext(IntPtr ctx);
        public delegate byte* Noesis_GetInputNameW();
        public delegate modelBone_s* Noesis_AllocBones(int numBones);
        public delegate noesisMatData_s* Noesis_GetMatData(noesisMaterial_s[] mats, int numMats, noesisTex_s[] tex, int numTex);
        //public delegate noesisMatData_s* Noesis_GetMatData(IntPtr mats, int numMats, IntPtr tex, int numTex);
        public delegate noesisMatData_s* Noesis_GetMatDataFromLists(IntPtr matsList, IntPtr texList);
        public delegate noesisMaterial_s* Noesis_GetMaterialList(int numMaterials, bool texByIndex);
        public delegate noesisTex_s* Noesis_LoadTexByHandler(byte* srcBuffer, int srcSize, byte[] extension);
        public delegate IntPtr Noesis_PooledAlloc(nuint size);
        public delegate byte* Noesis_PooledString(byte[] str);

        public delegate void RpgSetBoneMap(int[] boneRefMap);
        public delegate void RpgSetExData_Bones(modelBone_s* bones, int numBones);
        public delegate void RpgSetExData_Materials(noesisMatData_s* md);
        public delegate void RpgSetMaterialIndex(int index);
        public delegate IntPtr RpgConstructModel();
        public delegate void RpgBindPositionBuffer(byte[] data, rpgeoDataType_e dataType, int stride);
        public delegate void RpgBindNormalBuffer(byte[] data, rpgeoDataType_e dataType, int stride);
        public delegate void RpgBindUV1Buffer(byte[] data, rpgeoDataType_e dataType, int stride);
        public delegate void RpgBindUV2Buffer(byte[] data, rpgeoDataType_e dataType, int stride);
        public delegate void RpgBindUVXBuffer(byte[] data, rpgeoDataType_e dataType, int stride, int uvIndex, int elementCount);
        public delegate void RpgBindColorBuffer(byte[] data, rpgeoDataType_e dataType, int stride, int elementCount);
        public delegate void RpgBindBoneIndexBuffer(byte[] data, rpgeoDataType_e dataType, int stride, int numWeightsPerVert);
        public delegate void RpgBindBoneWeightBuffer(byte[] data, rpgeoDataType_e dataType, int stride, int numWeightsPerVert);
        public delegate void RpgCommitTriangles(byte[] indexData, rpgeoDataType_e dataType, int indexCount, rpgeoPrimType_e primType, bool usePlotMap);
        public delegate void RpgClearBufferBinds();

        public RpgCreateContext rpgCreateContext;
        public RpgDestroyContext rpgDestroyContext;
        public Noesis_GetInputNameW noesis_GetInputNameW;
        public Noesis_AllocBones noesis_AllocBones;
        public Noesis_GetMatData noesis_GetMatData;
        public Noesis_GetMatDataFromLists noesis_GetMatDataFromLists;
        public Noesis_GetMaterialList noesis_GetMaterialList;
        public Noesis_LoadTexByHandler noesis_LoadTexByHandler;
        public Noesis_PooledAlloc noesis_PooledAlloc;
        public Noesis_PooledString noesis_PooledString;

        public RpgSetBoneMap rpgSetBoneMap;
        public RpgSetExData_Bones rpgSetExData_Bones;
        public RpgSetExData_Materials rpgSetExData_Materials;
        public RpgSetMaterialIndex rpgSetMaterialIndex;
        public RpgBindPositionBuffer rpgBindPositionBuffer;
        public RpgBindNormalBuffer rpgBindNormalBuffer;
        public RpgBindUV1Buffer rpgBindUV1Buffer;
        public RpgBindUV2Buffer rpgBindUV2Buffer;
        public RpgBindUVXBuffer rpgBindUVXBuffer;
        public RpgBindColorBuffer rpgBindColorBuffer;
        public RpgBindBoneIndexBuffer rpgBindBoneIndexBuffer;
        public RpgBindBoneWeightBuffer rpgBindBoneWeightBuffer;
        public RpgCommitTriangles rpgCommitTriangles;
        public RpgClearBufferBinds rpgClearBufferBinds;
        public RpgConstructModel rpgConstructModel;

        public RAPIObj(noeRAPI_s* rapi_s)
        {
            noesis_GetInputNameW = Marshal.GetDelegateForFunctionPointer<Noesis_GetInputNameW>(rapi_s->Noesis_GetInputNameW);
            noesis_AllocBones = Marshal.GetDelegateForFunctionPointer<Noesis_AllocBones>(rapi_s->Noesis_AllocBones);
            noesis_GetMatData = Marshal.GetDelegateForFunctionPointer<Noesis_GetMatData>(rapi_s->Noesis_GetMatData);
            noesis_GetMatDataFromLists = Marshal.GetDelegateForFunctionPointer<Noesis_GetMatDataFromLists>(rapi_s->Noesis_GetMatDataFromLists);
            noesis_LoadTexByHandler = Marshal.GetDelegateForFunctionPointer<Noesis_LoadTexByHandler>(rapi_s->Noesis_LoadTexByHandler);
            noesis_GetMaterialList = Marshal.GetDelegateForFunctionPointer<Noesis_GetMaterialList>(rapi_s->Noesis_GetMaterialList);
            noesis_PooledString = Marshal.GetDelegateForFunctionPointer<Noesis_PooledString>(rapi_s->Noesis_PooledString);
            noesis_PooledAlloc = Marshal.GetDelegateForFunctionPointer<Noesis_PooledAlloc>(rapi_s->Noesis_PooledAlloc);

            rpgSetBoneMap = Marshal.GetDelegateForFunctionPointer<RpgSetBoneMap>(rapi_s->rpgSetBoneMap);
            rpgSetExData_Bones = Marshal.GetDelegateForFunctionPointer<RpgSetExData_Bones>(rapi_s->rpgSetExData_Bones);
            rpgSetExData_Materials = Marshal.GetDelegateForFunctionPointer<RpgSetExData_Materials>(rapi_s->rpgSetExData_Materials);
            rpgCreateContext = Marshal.GetDelegateForFunctionPointer<RpgCreateContext>(rapi_s->rpgCreateContext);
            rpgDestroyContext = Marshal.GetDelegateForFunctionPointer<RpgDestroyContext>(rapi_s->rpgDestroyContext);
            rpgSetMaterialIndex = Marshal.GetDelegateForFunctionPointer<RpgSetMaterialIndex>(rapi_s->rpgSetMaterialIndex);
            rpgConstructModel = Marshal.GetDelegateForFunctionPointer<RpgConstructModel>(rapi_s->rpgConstructModel);
            rpgBindPositionBuffer = Marshal.GetDelegateForFunctionPointer<RpgBindPositionBuffer>(rapi_s->rpgBindPositionBuffer);
            rpgBindNormalBuffer = Marshal.GetDelegateForFunctionPointer<RpgBindNormalBuffer>(rapi_s->rpgBindNormalBuffer);
            rpgBindUV1Buffer = Marshal.GetDelegateForFunctionPointer<RpgBindUV1Buffer>(rapi_s->rpgBindUV1Buffer);
            rpgBindUV2Buffer = Marshal.GetDelegateForFunctionPointer<RpgBindUV2Buffer>(rapi_s->rpgBindUV2Buffer);
            rpgBindUVXBuffer = Marshal.GetDelegateForFunctionPointer<RpgBindUVXBuffer>(rapi_s->rpgBindUVXBuffer);
            rpgBindColorBuffer = Marshal.GetDelegateForFunctionPointer<RpgBindColorBuffer>(rapi_s->rpgBindColorBuffer);
            rpgBindBoneIndexBuffer = Marshal.GetDelegateForFunctionPointer<RpgBindBoneIndexBuffer>(rapi_s->rpgBindBoneIndexBuffer);
            rpgBindBoneWeightBuffer = Marshal.GetDelegateForFunctionPointer<RpgBindBoneWeightBuffer>(rapi_s->rpgBindBoneWeightBuffer);
            rpgClearBufferBinds = Marshal.GetDelegateForFunctionPointer<RpgClearBufferBinds>(rapi_s->rpgClearBufferBinds);
            rpgCommitTriangles = Marshal.GetDelegateForFunctionPointer<RpgCommitTriangles>(rapi_s->rpgCommitTriangles);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct mathImpFn_s
    {
        public IntPtr Math_CalcPlaneEq;
        public IntPtr Math_Max2;
        public IntPtr Math_Max3;
        public IntPtr Math_Min2;
        public IntPtr Math_Min3;
        public IntPtr Math_TransformPointByMatrix;
        public IntPtr Math_TransformPointByMatrixNoTrans;
        public IntPtr Math_MatrixInverse;
        public IntPtr Math_TransformPointByMatrix4x4;
        public IntPtr Math_MatrixInverse4x4;
        public IntPtr Math_MatRotDist;
        public IntPtr Math_VecRotDist;
        public IntPtr Math_MatToAngles;
        public IntPtr Math_AnglesToMat;
        public IntPtr Math_AngleVectors;
        public IntPtr Math_MatrixIsSkewed;
        public IntPtr Math_OrthogonalizeMatrix;
        public IntPtr Math_LerpMatricesQ;
        public IntPtr Math_LerpMatrices;
        public IntPtr Math_RotationMatrix;
        public IntPtr Math_MatrixMultiply;
        public IntPtr Math_4x4ToModelMat;
        public IntPtr Math_ModelMatToGL;
        public IntPtr Math_ModelMatFromGL;
        public IntPtr Math_TransposeMat;
        public IntPtr Math_TranslateMatrix;
        public IntPtr Math_RotateMatrix;
        public IntPtr Math_MatrixMultiply4x4;
        public IntPtr Math_RotationMatrix4x4;
        public IntPtr Math_TranslateMatrix4x4;
        public IntPtr Math_RotateMatrix4x4;
        public IntPtr Math_AxisForNormal;
        public IntPtr Math_ExpandBounds;
        public IntPtr Math_MaxExtent;
        public IntPtr Math_PointInOnBox;
        public IntPtr Math_BoxesOverlap;
        public IntPtr Math_PlaneFromPoints;
        public IntPtr Math_ConfinePointToBox;
        public IntPtr Math_BuildBoxPlanes2D;
        public IntPtr Math_VecCopy;
        public IntPtr Math_VecSub;
        public IntPtr Math_VecSub2;
        public IntPtr Math_VecAdd;
        public IntPtr Math_VecScale;
        public IntPtr Math_VecScaleVec;
        public IntPtr Math_VecNorm;
        public IntPtr Math_DotProduct;
        public IntPtr Math_CrossProduct;
        public IntPtr Math_VecLen;
        public IntPtr Math_VecLenSq;
        public IntPtr Math_VecLen2;
        public IntPtr Math_VecMA;
        public IntPtr Math_VecToAngles;
        public IntPtr Math_ProjectOntoPlane;
        public IntPtr Math_PointInTriPlanes;
        public IntPtr Math_ConfinePointToTri;
        public IntPtr Math_GetTriEdgeFracs;
        public IntPtr Math_ConstantLerp;
        public IntPtr Math_LinearLerp;
        public IntPtr Math_BilinearLerp;
        public IntPtr Math_TriLerp;
        public IntPtr Math_CubicLerp;
        public IntPtr Math_PlaneDist;
        public IntPtr Math_GetFloat16;
        public IntPtr Math_QuatToMat;
        public IntPtr Math_MatToQuat;
        public IntPtr Math_QuatSlerp;
        public IntPtr Math_NextPow2;
        public IntPtr Math_CheckPointInTri;
        public IntPtr Math_ExpandTriangle;
        public IntPtr Math_GetMappedValue;
        public IntPtr Math_RandSetSeed;
        public IntPtr Math_RandInt;
        public IntPtr Math_RandFloat;
        public IntPtr Math_RandIntOnSeed;
        public IntPtr Math_RandFloatOnSeed;
        public IntPtr Math_RandIntUnseeded;
        public IntPtr Math_RandFloatUnseeded;

        //noesis 2.6 and later
        public IntPtr Math_AngleMod;
        public IntPtr Math_BlendAngleLinear;
        public IntPtr Math_RotateMatrixTP;

        //noesis 3.46 and later
        public IntPtr Math_EncodeFloat16;

        //noesis 3.56 and later
        public IntPtr Math_AnglesToMatAxis;

        //noesis 3.66 and later
        public IntPtr Math_TransformPointByMatrixD;
        public IntPtr Math_TransformPointByMatrixNoTransD;
        public IntPtr Math_MatrixInverseD;
        public IntPtr Math_MatrixMultiplyD;
        public IntPtr Math_MatrixDToMatrix;
        public IntPtr Math_MatrixToMatrixD;

        //noesis 3.862 and later
        public IntPtr Math_Morton2D;

        //noesis 3.996 and later
        public IntPtr Math_WorldToScreenSpace;
        public IntPtr Math_ScreenToWorldSpace;
        public IntPtr Math_PointRelativeToPlane;
        public IntPtr Math_LineIntersectTri;

        //noesis 4.0799 and later
        public IntPtr Math_CatmullRomLerp;
        public IntPtr Math_HermiteLerp;
        public IntPtr Math_Bezier3D;
        public IntPtr Math_ClampInt;
        public IntPtr Math_WrapInt;

        //noesis 4.081 and later
        public IntPtr Math_CubicBezier3D;
        public IntPtr Math_BezierTangent3D;

        //noesis 4.0824 and later
        public IntPtr Math_CatmullRomTangent;
        public IntPtr Math_CatmullRomLerp3D;
        public IntPtr Math_CatmullRomTangent3D;
        public IntPtr Math_CreateProjectionMatrix;

        //noesis 4.143 and later
        //encode/decode functions assume all 0 exponent bits equal 0, and don't handle any other IEEE standards cases.
        //exponent bias for source and destination formats is assumed to be 2^(exponentBits-1)-1.
        public IntPtr Math_EncodeFloatBitsFromBits;
        public IntPtr Math_DecodeFloatFromBits;

        //noesis 4.144 and later

        //get base-e log for v
        public IntPtr Math_Log;

        //get base-2 log for v
        public IntPtr Math_Log2;

        //get base-e log for v (double)
        public IntPtr Math_LogD;

        //get base-2 log for v (double)
        public IntPtr Math_Log2D;

        //convert from linear color space to gamma space
        public IntPtr Math_LinearToGamma;

        //convert from gamma space to linear space
        public IntPtr Math_GammaToLinear;

        //convert from linear color space to gamma space (double)
        public IntPtr Math_LinearToGammaD;

        //convert from gamma space to linear space (double)
        public IntPtr Math_GammaToLinearD;

        //calculates fraction bits with the IEEE-based assumption of a leading 1.
        //because the leading 1 is assumed, fractionValues starting under 1 will return a best-case of 0.
        public IntPtr Math_CalculateFractionBits;

        //as above, assuming 32-bit float.
        public IntPtr Math_CalculateFractionBits32;

        //calculates exponent bits, explicitly clamping between values of 0 and (2^exponentBitCount)-1 under the assumption
        //that those values are reserved as per IEEE 754.
        public IntPtr Math_CalculateExponentBits;

        //as above, assuming 32-bit float.
        public IntPtr Math_CalculateExponentBits32;

        //extracts the fraction and exponent from a 32-bit float.
        public IntPtr Math_ExtractFractionAndExponent32;

        //extracts the fraction and exponent from a 64-bit float.
        public IntPtr Math_ExtractFractionAndExponent64;

        public IntPtr Math_TransformQST;

        public IntPtr Math_GetFirstLastBitSet64;

        public IntPtr Math_SHProjectCubemap;

        //unless otherwise specified, inputs and outputs assume 4-channel rgba
        public IntPtr Math_CreateIrradianceCubemap;
        public IntPtr Math_CreateIrradianceCubemapLambert;
        public IntPtr Math_PrefilterCubemapGGX;
        //Math_SampleSphericalProjectiointoHDRCubemap flags - 1: flip theta, 2: flip phi
        public IntPtr Math_SampleSphericalProjectiointoHDRCubemap;

        //calculate approximate derivative of pFn(x)
        public IntPtr Math_CalculateDerivative;
        //calculate definite integral of pFn(x) from xMin to xMax, stopping when delta is < errorTolerance
        public IntPtr Math_CalculateIntegral;

        //DFT & DCT functions are not at all optimized and were done from original formulas as a reference implementation. makes it easier to see data transforms under the hood when doing things
        //properly and not using bit twiddling/look tables/etc. if you have a serious use for these, you should probably be using something like FFTW instead.
        //note that transformed dft input/output (RichComplex) is in the form of complex double*2 numbers. you can cast this memory as std::complex<double> to operate on it.
        public IntPtr Math_DiscreteFourierTransform;
        public IntPtr Math_InverseDiscreteFourierTransform;
        public IntPtr Math_DiscreteFourierTransform2D;
        public IntPtr Math_InverseDiscreteFourierTransform2D;

        public IntPtr Math_DiscreteCosineTransform;
        public IntPtr Math_InverseDiscreteCosineTransform;
        public IntPtr Math_DiscreteCosineTransform2D;
        public IntPtr Math_InverseDiscreteCosineTransform2D;
        public IntPtr Math_DiscreteCosineTransform3D;
        public IntPtr Math_InverseDiscreteCosineTransform3D;

        public IntPtr Math_QuatMultiply;

        //reserved, do not call.
        public IntPtr resvA;
        public IntPtr resvB;
        public IntPtr resvC;
        public IntPtr resvD;
        public IntPtr resvE;
        public IntPtr resvF;
        public IntPtr resvG;
        public IntPtr resvH;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct noePluginFn_s
    {
        //=========================
        //engine-provided functions
        //=========================

        //note that rapi handles can be passed from multiple different and concurrent noesis core instances. you should always deal with the local rapi
        //function set.

        //returns a handle to a new type for this module.
        public IntPtr NPAPI_Register;
        //sets the callback for "is this data of this type?"
        public IntPtr NPAPI_SetTypeHandler_TypeCheck;
        //sets the callback to load model data
        public IntPtr NPAPI_SetTypeHandler_LoadModel;
        //sets the callback to write model data
        public IntPtr NPAPI_SetTypeHandler_WriteModel;
        //sets the callback to load pixel data
        public IntPtr NPAPI_SetTypeHandler_LoadRGBA;
        //sets the callback to write pixel data
        public IntPtr NPAPI_SetTypeHandler_WriteRGBA;
        //sets the callback to write animation data
        public IntPtr NPAPI_SetTypeHandler_WriteAnim;
        //sets the callback to extract an archive
        public IntPtr NPAPI_SetTypeHandler_ExtractArc;

        //gets the handle for the main window. make sure to check if this is non-0, as it can be called before the main Noesis window is created.
        public IntPtr NPAPI_GetMainWnd;

        //gets the noesis api version
        public IntPtr NPAPI_GetAPIVersion;

        //sets the callback to extract an archive in direct-stream mode (new in Noesis 2.5)
        public IntPtr NPAPI_SetTypeHandler_ExtractArcStream;

        //allows you to add advanced/commandline option hooks for your program (new in Noesis 3.22)
        //if successful, returns a pointer to the variable store for the option.
        public IntPtr NPAPI_AddTypeOption;

        //New in Noesis 3.46
        //dst is assumed to be at least MAX_NOESIS_PATH wchars
        public IntPtr NPAPI_GetExecutablePath;
        //returns number of files found, calls fileCallback (if non-null) for each file found. example:
        //NPAPI_EnumerateFiles(noesisPathDir, L"plugins", L"*.dll", myPathHandler);
        public IntPtr NPAPI_EnumerateFiles;

        //plugins are allowed a single critical section to avoid processing-previewing conflicts. resv MUST BE 0 for these calls.
        public IntPtr NPAPI_EnterCritical;
        public IntPtr NPAPI_LeaveCritical;
        //allows a plugin to invoke the debug log. resv must be 0.
        public IntPtr NPAPI_PopupDebugLog;
        //logs a debug string
        public IntPtr NPAPI_DebugLogStr;

        //New in Noesis 3.84
        //this handler intercepts *all* image exports for the active export, and feeds them to the batch write handler. This can be useful for compiling animations from an array of textures.
        public IntPtr NPAPI_SetTypeHandler_WriteRGBABatch;

        //New in Noesis 3.89
        //creates and displays a user prompt, returns true if the callback handler approved the input and the user hit ok, otherwise false
        //if the return value is true, the contents of the input are stored in the param structure's valBuf, to be casted to the appropriate type based on the value of valType.
        public IntPtr NPAPI_UserPrompt;
        //displays a message in a standard dialog prompt
        public IntPtr NPAPI_MessagePrompt;
        //returns a handle to a new tool for this module.
        public IntPtr NPAPI_RegisterTool;
        //returns the user data for a tool by index
        public IntPtr NPAPI_GetToolUserData;

        //New in Noesis 3.9
        //dst is assumed to be at least MAX_NOESIS_PATH wchars
        public IntPtr NPAPI_GetScenesPath;
        //tells noesis to open a new file in the main preview view
        public IntPtr NPAPI_OpenFile;

        //New in Noesis 3.93
        //it is recommended that you try to use unique names (for example, prefix all setting names with your plugin name) when reading/writing settings to avoid conflicts with other plugins.
        //writes a chunk of binary for a user plugin
        public IntPtr NPAPI_UserSettingWrite;
        //reads a chunk of binary for a user plugin
        public IntPtr NPAPI_UserSettingRead;
        //performs a task on a job thread. jobHandle may be NULL if you do not need to query for the completion of the job.
        public IntPtr NPAPI_Threads_DoJob;
        //checks if a job is done yet
        public IntPtr NPAPI_Threads_JobDone;
        //runs the windows message pump. should only be used by tools and when you know what you're doing.
        public IntPtr NPAPI_DoPump;
        //returns internal afx app handle. again should only be used when you know what you're doing.
        public IntPtr NPAPI_GetAfxWinApp;

        //New in Noesis 3.97
        //will return null if memory maps are disabled in preferences
        public IntPtr NPAPI_AllocMappedFile;
        public IntPtr NPAPI_DestroyMappedFile;
        //returns engine-allocated rgba buffer
        public IntPtr NPAPI_LoadImageRGBA;
        //returns true if write was successful
        public IntPtr NPAPI_SaveImageRGBA;
        //engine-allocated pointers must be freed with NPAPI_EngineFree
        public IntPtr NPAPI_EngineAlloc;
        public IntPtr NPAPI_EngineFree;
        //module instantiation can be performed from tools. always remember to free the module when you're finished with it, or you will bog Noesis down.
        public IntPtr NPAPI_InstantiateModule;
        public IntPtr NPAPI_FreeModule;
        public IntPtr NPAPI_GetModuleRAPI;
        //fills in a buffer (expected to be MAX_NOESIS_PATH wchars) with the currently selected file in the viewer. "" is no selection is made.
        public IntPtr NPAPI_GetSelectedFile;

        //New in Noesis 3.994
        //sets implicit export options for the format
        public IntPtr NPAPI_SetTypeExportOptions;

        //New in Noesis 3.996
        //sets menu help text for a tool entry
        public IntPtr NPAPI_SetToolHelpText;
        //gets a pointer to the rapi interface for the active preview model. NULL if nothing is loaded.
        public IntPtr NPAPI_GetPreviewRAPI;
        //register a visualizer
        public IntPtr NPAPI_RegisterVisualizer;
        //set visualizer pre model render callback
        public IntPtr NPAPI_Visualizer_SetPreRender;
        //set visualizer post model render callback
        public IntPtr NPAPI_Visualizer_SetPostRender;
        //set visualizer callback for after preview model is loaded (called after successful load)
        public IntPtr NPAPI_Visualizer_SetPreviewLoaded;
        //set visualizer callback for when preview is closed (called before close)
        public IntPtr NPAPI_Visualizer_SetPreviewClose;
        //set visualizer callback for when preview is reset (f12/middlemouse)
        public IntPtr NPAPI_Visualizer_SetPreviewReset;
        //set visualizer callback for new input
        public IntPtr NPAPI_Visualizer_SetInput;
        //checks or unchecks a tool's menu item
        public IntPtr NPAPI_CheckToolMenuItem;

        //New in Noesis 4.02
        //gets a program setting. returns NULL if setting doesn't exist.
        public IntPtr NPAPI_GetProgramSetting;
        //returns true if debug log is open
        public IntPtr NPAPI_DebugLogIsOpen;
        //reloads all plugins
        public IntPtr NPAPI_ReloadPlugins;

        //New in Noesis 4.04
        //dst is assumed to be at least MAX_NOESIS_PATH wchars
        public IntPtr NPAPI_GetPluginsPath;
        //returns true if a forced reload is occurring
        public IntPtr NPAPI_IsTriggeredPluginReload;
        //dst is assumed to be at least MAX_NOESIS_PATH wchars, or dst may be NULL
        public IntPtr NPAPI_GetOpenPreviewFile;

        //New in Noesis 4.061
        //fills in a buffer (expected to be MAX_NOESIS_PATH wchars) with the currently selected directory in the viewer. "" is no selection is made.
        public IntPtr NPAPI_GetSelectedDirectory;

        //New in Noesis 4.066
        public IntPtr Array_Alloc;
        public IntPtr Array_Free;
        public IntPtr Array_SetGrowth;
        public IntPtr Array_QSort;
        public IntPtr Array_GetElement;
        public IntPtr Array_GetElementGrow;
        public IntPtr Array_Append;
        public IntPtr Array_RemoveLast;
        public IntPtr Array_Insert;
        public IntPtr Array_Remove;
        public IntPtr Array_GetCount;
        public IntPtr Array_Reset;
        public IntPtr Array_Tighten;

        public IntPtr Stream_Alloc;
        public IntPtr Stream_AllocFixed;
        public IntPtr Stream_Free;
        public IntPtr Stream_WriteBits;
        public IntPtr Stream_WriteBytes;
        public IntPtr Stream_ReadBits;
        public IntPtr Stream_ReadBytes;
        public IntPtr Stream_WriteBool;
        public IntPtr Stream_WriteInt;
        public IntPtr Stream_WriteFloat;
        public IntPtr Stream_WriteString;
        public IntPtr Stream_WriteWString;
        public IntPtr Stream_ReadBool;
        public IntPtr Stream_ReadInt;
        public IntPtr Stream_ReadFloat;
        public IntPtr Stream_ReadString;
        public IntPtr Stream_Buffer;
        public IntPtr Stream_Size;
        public IntPtr Stream_SetOffset;
        public IntPtr Stream_GetOffset;
        public IntPtr Stream_SetFlags;
        public IntPtr Stream_GetFlags;
        public IntPtr Steam_WriteToFile;

        //New in Noesis 4.081
        public IntPtr Noesis_GetCharSplineSet;

        //New in Noesis 4.084
        //should be some combination of NTOOLFLAG values
        public IntPtr NPAPI_SetToolFlags;
        public IntPtr NPAPI_GetToolFlags;
        //sets visibility callback. if it's a context item and a file is selected, focusFileName will be the full path to the selected file.
        //otherwise, the value will be NULL.
        //the callback should return 1 if the menu is visible, otherwise 0.
        public IntPtr NPAPI_SetToolVisibleCallback;
        //returns some combination of NFORMATFLAG values.
        //ext should be the file extension including the dot, e.g. ".png"
        //if the extension is used by multiple format handlers, expect to get flags from all applicable formats.
        //(numHandlers will also be set appropriately if you pass a non-NULL value)
        public IntPtr NPAPI_GetFormatExtensionFlags;
        //tells noesis to open a new file in the main preview view, then delete it
        public IntPtr NPAPI_OpenAndRemoveTempFile;

        //selects a mesh in the data viewer, may be used by tool plugins.
        public IntPtr NPAPI_SelectDataViewerMesh;

        //selects a mesh's material in the data viewer, may be used by tool plugins.
        public IntPtr NPAPI_SelectDataViewerMeshMaterial;

        //selects a bone in the data viewer, may be used by tool plugins.
        public IntPtr NPAPI_SelectDataViewerBone;

        public IntPtr NPAPI_Visualizer_SetRawKeyDownHook;
        public IntPtr NPAPI_Visualizer_SetRawKeyUpHook;
        public IntPtr NPAPI_Visualizer_SetOverrideRenders;

        public IntPtr NPAPI_FileIsLoadable;

        public IntPtr NPAPI_DisableFormatByDescription;

        public IntPtr NPAPI_HighPrecisionTime; //in seconds

        public IntPtr NPAPI_AddUserExtProc;
        public IntPtr NPAPI_GetUserExtProc;

        public IntPtr Stream_SetBitOffset;
        public IntPtr Stream_GetBitOffset;

        public IntPtr NPAPI_PumpModalStatus;
        public IntPtr NPAPI_ClearModalStatus;

        public IntPtr NPAPI_GetResourceHandle;

        public IntPtr NPAPI_GetDirectoryList;

        //returns 1 for file, 2 for directory, otherwise
        public IntPtr NPAPI_PathExists;
        public IntPtr NPAPI_PathNormalize;

        public IntPtr Stream_ReadRevBits;

        public IntPtr NPAPI_SetGlobalMemForRAPI;

        public IntPtr NPAPI_SetToolSubMenuName;

        public IntPtr NPAPI_RegisterVRMenuItem;
        public IntPtr NPAPI_EnterCustomVRMenuState;
        public IntPtr NPAPI_SetCustomVRMenuItem;

        public IntPtr NPAPI_IsSupportedFileExtension;

        public IntPtr NPAPI_OpenDataViewer;
        public IntPtr NPAPI_CloseDataViewer;
        public IntPtr NPAPI_GetDataViewerSetting;
        public IntPtr NPAPI_SetDataViewerSetting;

        //returns true if write was successful
        public IntPtr NPAPI_SaveImageFromTexture;

        //reserved, do not call.
        public IntPtr resvA;
        public IntPtr resvB;
        public IntPtr resvC;
        public IntPtr resvD;
        public IntPtr resvE;
        public IntPtr resvF;
        public IntPtr resvG;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct noeRAPI_s
    {
        public IntPtr Noesis_PooledAlloc; //pooled allocations are automatically cleared once the preview/conversion is closed/reset
        public IntPtr Noesis_PooledString;
        public IntPtr Noesis_UnpooledAlloc; //you must free up unpooled allocations yourself
        public IntPtr Noesis_UnpooledFree;

        public IntPtr Noesis_CreateStrPool;
        public IntPtr Noesis_DestroyStrPool;
        public IntPtr Noesis_StrPoolGetOfs;
        public IntPtr Noesis_StrPoolSize;
        public IntPtr Noesis_StrPoolMem;

        public IntPtr Noesis_GetExtProc;
        public IntPtr Noesis_GetExtList;

        public IntPtr Noesis_ReadFile; //you must free the pointer returned by Noesis_ReadFile with Noesis_UnpooledFree! (unless it's NULL)
        public IntPtr Noesis_WriteFile;
        public IntPtr Noesis_WriteFileMakePath;

        public IntPtr Noesis_LoadPairedFile; //creates an actual "open dialog" prompt for the user
        public IntPtr Noesis_GetOutputName;
        public IntPtr Noesis_GetInputName;
        public IntPtr Noesis_GetLastCheckedName;
        public IntPtr Noesis_CheckFileExt;
        public IntPtr Noesis_GetLocalFileName;
        public IntPtr Noesis_GetExtensionlessName;
        public IntPtr Noesis_GetDirForFilePath;

        public IntPtr Noesis_TextureAlloc;
        public IntPtr Noesis_GetMaterialList;
        public IntPtr Noesis_AnimAlloc;
        public IntPtr Noesis_GetMatData;
        public IntPtr Noesis_GetMatDataFromLists;

        public IntPtr Noesis_HasActiveGeometry;
        public IntPtr Noesis_GetActiveType;

        //RichPGeo exposure
        public IntPtr rpgCreateContext; //create a new context
        public IntPtr rpgDestroyContext; //always do this after you're done with a context
        public IntPtr rpgSetActiveContext; //note that rpgCreateContext will automatically set the newly-created context as the active one

        public IntPtr rpgReset;
        public IntPtr rpgSetMaterial;
        public IntPtr rpgSetMaterialIndex;
        public IntPtr rpgClearMaterials;
        public IntPtr rpgSetName;
        public IntPtr rpgClearNames;
        public IntPtr rpgClearMorphs;
        public IntPtr rpgSetTransform; //transforms all vertices/normals
        public IntPtr rpgSetPosScaleBias;
        public IntPtr rpgSetUVScaleBias;
        public IntPtr rpgSetBoneMap; //use this for models which use draw-relative bone indices
                                     //these 2 functions are deprecated, and should be replaced respectively with
                                     //rpgSetOption(RPGOPT_BIGENDIAN, isBig)
                                     //rpgSetOption(RPGOPT_TRIWINDBACKWARD, backward)
        public IntPtr rpgSetEndian;
        public IntPtr rpgSetTriWinding;

        public IntPtr rpgBegin;
        public IntPtr rpgEnd;

        public IntPtr rpgDataToInt;
        public IntPtr rpgDataToFloat;

        public IntPtr rpgVertex3f;
        public IntPtr rpgVertexX;
        public IntPtr rpgVertex3s;
        public IntPtr rpgVertex3hf;
        public IntPtr rpgVertNormal3f;
        public IntPtr rpgVertNormalX;
        public IntPtr rpgVertNormal3us;
        public IntPtr rpgVertNormal3s;
        public IntPtr rpgVertNormal3hf;
        public IntPtr rpgVertUV2f;
        public IntPtr rpgVertUVX;
        public IntPtr rpgVertUV2us;
        public IntPtr rpgVertUV2s;
        public IntPtr rpgVertUV2hf;
        public IntPtr rpgVertColor4f;
        public IntPtr rpgVertColorX;
        public IntPtr rpgVertColor4us;
        public IntPtr rpgVertColor4ub;
        public IntPtr rpgVertColor3f;
        public IntPtr rpgVertColor3us;
        public IntPtr rpgVertColor3ub;
        public IntPtr rpgVertBoneIndexI;
        public IntPtr rpgVertBoneIndexX;
        public IntPtr rpgVertBoneIndexUB;
        public IntPtr rpgVertBoneIndexUS;
        public IntPtr rpgVertBoneIndexUI;
        public IntPtr rpgVertBoneIndexB;
        public IntPtr rpgVertBoneIndexS;
        public IntPtr rpgVertBoneWeightF;
        public IntPtr rpgVertBoneWeightX;
        public IntPtr rpgVertBoneWeightHF;
        public IntPtr rpgVertBoneWeightUS;
        public IntPtr rpgVertBoneWeightUB;
        public IntPtr rpgVertMorphIndex;

        public IntPtr rpgBindPositionBuffer;
        public IntPtr rpgBindNormalBuffer;
        public IntPtr rpgBindUV1Buffer;
        public IntPtr rpgBindUV2Buffer;
        public IntPtr rpgBindColorBuffer;
        public IntPtr rpgBindBoneIndexBuffer;
        public IntPtr rpgBindBoneWeightBuffer;
        public IntPtr rpgClearBufferBinds;
        //morph target functionality
        public IntPtr rpgFeedMorphTargetPositions;
        public IntPtr rpgFeedMorphTargetNormals;
        //do not call CommitMorphFrame unless you are sure data fed by FeedMorphX will remain valid
        public IntPtr rpgCommitMorphFrame;
        //call once an entire morph set has been committed
        public IntPtr rpgCommitMorphFrameSet;

        //CommitTriangles should only be called once all of the appropriate vertex buffers are bound
        public IntPtr rpgCommitTriangles;

        public IntPtr rpgOptimize; //optimizes lists to remove duplicate vertices, sorts triangles by material, etc.
        public IntPtr rpgConstructModel; //constructs the model from all given input
        public IntPtr rpgFromModel; //constructs the RichPGeo's contents from a model (returns false if it failed)

        public IntPtr rpgSetExData_Bones;
        public IntPtr rpgSetExData_Materials;
        public IntPtr rpgSetExData_Anims;

        //this interface exists in order to allow the noesis model structures to change freely and drastically without breaking plugin compatibility.
        //accessing data directly around a noesisModel_t would be extremely unwise, and virtually guarantees future versions of noesis will break your plugin.
        //additionally, you needn't worry about freeing/destroying shared model handles, as they're pool-allocated.
        public IntPtr rpgGetSharedModel;

        //creates transformed vertex arrays using the provided animation matrices
        public IntPtr rpgTransformModel;

        //grabs various extents of the model, using transformed positions if available. any input may be null if it's not desired.
        public IntPtr rpgGetModelExtents;

        //extracts a list of parent-relative matrices from an animation, in the format of ((matrix for each bone) for each frame).
        //if pooled is false, non-null returned pointer must be freed, via Noesis_UnpooledFree.
        public IntPtr rpgMatsFromAnim;

        //rpgAnimFromBonesAndMats expects a list of matrices, ordered as ((matrix for each bone) for each frame)
        //animation matrices should be fed as parent-relative. data does not need to be freed. (it's pooled)
        //IMPORTANT NOTE!!!!!!!
        //you should use rpgAnimFromBonesAndMatsFinish instead if you are passing the final data for export (which is going to be most of the time)
        //only use this function instead of rpgAnimFromBonesAndMatsFinish when you are going to be ripping the data back out for your own local purposes.
        public IntPtr rpgAnimFromBonesAndMats;

        public IntPtr rpgMultiplyBones;

        public IntPtr SetPreviewAnimSpeed;
        public IntPtr SetPreviewAngOfs;

        public IntPtr LogOutput;

        //ADDED IN NOESIS 2.1
        //performs rpgAnimFromBonesAndMats, and adds additional process-global rotations, translations, etc. to the animation matrices
        public IntPtr rpgAnimFromBonesAndMatsFinish;

        //ADDED IN NOESIS 2.2
        //returns a value string for an option, or NULL if the option is not available.
        public IntPtr Noesis_GetOption;
        //takes a source rgba32 image, a destination 8bpp (palette index) of the same dimensions, and a 256-entry rgba32 (1024 bytes) palette.
        //fills in the contents of dstPix appropriately, using the provided palette to match colors from the rgba32 image.
        public IntPtr Noesis_ApplyPaletteRGBA;
        //same as Noesis_ApplyPaletteRGBA, except the dstPal is filled in with this operation. if firstClear is set, the first entry in the palette
        //is set to (0,0,0,0) (black, no alpha)
        public IntPtr Noesis_PalettizeRGBA;
        //sets and gets extra animation data, to be checked/used by formats that wish to compile animation data into output models
        public IntPtr Noesis_SetExtraAnimData;
        public IntPtr Noesis_GetExtraAnimData;
        //loads model textures into a single list, including externally-referenced textures. note that this may change the address of material data.
        public IntPtr Noesis_LoadTexturesForModel;
        //creates a single RGBA32 texture page from a list of textures, filling pageWidth and pageHeight with the end result's dimensions.
        //after calling this function, the texref's pageX/Y values can be used to locate the texture within the page.
        //non-null returned pointer must be freed with Noesis_UnpooledFree.
        public IntPtr Noesis_CreateRefImagePage;
        //performs a bilinear image resize on rgba32 image data
        public IntPtr Noesis_ResampleImageBilinear;
        //generates a list of triangle strip indices from a mesh triangle list (stripOut pointer is pool-allocated)
        public IntPtr rpgGenerateStripIndices;
        //generates a list of triangle strips, each of which can contain indices in the form of triangle lists or strips. (unless doStitch is true, which results in a single list of strip indices)
        //all data provided by this function is pool-allocated.
        public IntPtr rpgGenerateStripLists;
        //text parsing functions
        public IntPtr Parse_InitParser;
        public IntPtr Parse_InitParserFromFile;
        public IntPtr Parse_WhiteSpace;
        public IntPtr Parse_FreeParser;
        public IntPtr Parse_EnableInclude;
        public IntPtr Parse_GetNextToken;
        //check if a file exists
        public IntPtr Noesis_FileExists;

        //ADDED IN NOESIS 2.3
        //allows you to specify an array of animation data
        public IntPtr rpgSetExData_AnimsNum;
        //creates a contiguous block of animations from a list (pool-allocated)
        public IntPtr Noesis_AnimsFromList;
        //creates a contiguous block of models from a list (pool-allocated)
        public IntPtr Noesis_ModelsFromList;
        //procedurally generates an animation, rotating given bone(s) along given axis(es). useful for testing your bone weights.
        public IntPtr rpgCreateProceduralAnim;
        //DEPRECATED. DO NOT USE.
        public IntPtr Noesis_AllocBones_369_DEPRECATED;
        //allocates a placeholder texture
        public IntPtr Noesis_AllocPlaceholderTex;
        //performs a variety of normal-correction operations on a single 4-byte rgba32 pixel
        public IntPtr Noesis_SwizzleNormalPix;
        //untiles raw pixel data
        public IntPtr Noesis_UntileImageRAW;
        //untiles dxt-encoded pixel data
        public IntPtr Noesis_UntileImageDXT;

        //ADDED IN NOESIS 2.5
        //decompression functions return < 0 on failure.
        //zlib inflate (return 0 means success)
        public IntPtr Decomp_Inflate;
        //puff
        public IntPtr Decomp_Puff;
        //blast
        public IntPtr Decomp_Blast;
        //lzs used in ff7/ff8
        public IntPtr Decomp_LZS01;
        //used in various capcom games, mainly
        public IntPtr Decomp_FPK;
        //lzma
        public IntPtr Decomp_LZMA;
        //lzo 1x (used in silent hill homecoming, maybe others)
        public IntPtr Decomp_LZO;
        //lzo (used in metroid prime 2, maybe others)
        public IntPtr Decomp_LZO2;
        //zlib deflate, returns compressed size
        public IntPtr Compress_Deflate;
        //compress lzma, recommended settings: level=9, dictSize=(1<<16), lc=3, lp=0, pb=2, fb=32, returns compressed size
        public IntPtr Compress_LZMA;
        //converts dxt data to rgba32. dxtFmt is the FOURCC code for the pixel data. you must free the non-null return pointer with Noesis_UnpooledFree.
        //this function also handles FOURCC_ATI2. (special normal compression mode)
        public IntPtr Noesis_ConvertDXT;
        //untwiddles data which has been twiddled for the psp gpu. pixDataSize (in bytes) can be larger than width*height*bpp would dictate, to indicate padding.
        public IntPtr Noesis_UntwiddlePSP;
        //writes an exported file entry from an archive. filename should be the archive-relative path, NOT the absolute path.
        public IntPtr Noesis_ExportArchiveFile;
        //opens a FILE stream in binary write mode, using the same path system as the above function. you are responsible for closing the file.
        //DO NOT USE THIS FUNCTION ANYMORE - use Noesis_ExportArchiveFileOpen instead
        public IntPtr Noesis_ExportArchiveFileOpenDEPRECATED;

        //new in Noesis 2.7
        //get a bone list along with other anim data, which describes hierarchy and anim bones
        public IntPtr rpgMatsAndInfoFromAnim;
        //final output point for export of animation data
        public IntPtr Noesis_WriteAnimFile;
        //allocate animation sequence data
        public IntPtr Noesis_AnimSequencesAlloc;
        //allocate a model container
        public IntPtr Noesis_AllocModelContainer;
        //generic lzss decompression. an example for schemes commonly seen on the wii would be
        //Decomp_LZSSGeneric(srcBuf, dstBuf, srcSize, dstSize, 8, 4, 12, false, 3, -1, true, false, true);
        public IntPtr Decomp_LZSSGeneric;
        //do a qsort operation on a bone list. returns pointer to a mapping of which bone went where. map is pool-allocated and does not need to be freed.
        //this function also re-associates parents correctly within the bones list. if postHieSort is true, final list will also be sorted by hierarchy.
        public IntPtr Noesis_QSortBones;
        //pool-allocates a full copy of the bones list, correctly adjusts parent, etc. pointers
        public IntPtr Noesis_CopyBones;
        //uses hashing to quickly create a list of unique elements. (using memory comparison)
        //returned pointer is to a list of unique elements, and must be freed with Noesis_UnpooledFree.
        //numElems will be modified to contain the output number of unique elments.
        //elemMap should be NULL, or an array of numElems ints, which will contain the mapped element indices from elemData into the returned array.
        public IntPtr Noesis_GetUniqueElements;

        //new in Noesis 2.95
        //allocate external texture reference memory, which you may attach to a noesisMaterial_t.
        //all memory (including string copies passed back on the object) is pooled and does not need to be freed.
        //any and/or all arguments may be null.
        public IntPtr Noesis_AllocTexRefsOLD;

        //sets preview options. current options available are:
        //key									value(s)
        //----------------------------------------------
        //"drawAllModels"						"0"/"1" (toggles drawing all models at once in preview mode by default)
        //"noTextureLoad"						"0"/"1" (toggles auto-loading of textures for previewed model based on tex/mat names)
        //"setAnimPlay"							"0"/"1" (if 1, auto-starts animation in preview)
        //"setSkelToShow"						"0"/"1" (if 1, displays skeleton by default)
        public IntPtr SetPreviewOption;

        //new in Noesis 2.97
        public IntPtr Noesis_GetOutputNameW;
        public IntPtr Noesis_GetInputNameW;
        public IntPtr Noesis_GetLastCheckedNameW;
        public IntPtr Noesis_CheckFileExtW;
        public IntPtr Noesis_GetLocalFileNameW;
        public IntPtr Noesis_GetExtensionlessNameW;
        public IntPtr Noesis_GetDirForFilePathW;
        //sets anim data for a model. this call is only necessary to set animations for a model if rpgSetExData_Anims was not used before its creation.
        public IntPtr Noesis_SetModelAnims;
        //sets material data for a model. this call is only necessary to set materials for a model if rpgSetExData_Materials was not used before its creation.
        public IntPtr Noesis_SetModelMaterials;
        public IntPtr Noesis_LoadPairedFileW;
        public IntPtr Noesis_ReadFileW; //you must free the pointer returned by Noesis_ReadFile with Noesis_UnpooledFree! (unless it's NULL)
        public IntPtr Noesis_WriteFileW;
        public IntPtr Noesis_WriteFileMakePathW;

        //new in Noesis 2.98
        //checks the properties of a material against others in the list, and returns the index of a material that matches if one already exists. if none exists, returns index of the new material in the list.
        //if the includeName argument is true, the names of the materials will also be compared in checking that they are identical.
        public IntPtr Noesis_FindOrAddMaterial;
        //if enabled is non-0, the model will have its triangles sorted by material and distance from the viewer before being drawn.
        //enabled=1 means that triangles will be sorted by distance of mesh before distance of triangles, generally keeping draw batching intact.
        //enabled=2 means that triangles will be sorted purely by their own distance. however, this can interrupt draw batching, creating thousands of draw calls and destroying performance.
        public IntPtr Noesis_SetModelTriSort;

        //new in Noesis 2.981
        public IntPtr rpgConstructModelAndSort; //performs rpgConstructModel with a triangle sort

        //new in Noesis 2.99
        //performs an in-place ps2 untwiddling. bpp (bits per pixel) must be 4 or 8.
        public IntPtr Noesis_UntwiddlePS2;

        //new in Noesis 3.0
        //creates a single animation with a sequence list from all of the combined animations fed in.
        //all animations must have the same bone count, or the function will fail and return NULL.
        public IntPtr Noesis_AnimFromAnims;
        //identical to Noesis_AnimFromAnims, but accepts a pointer list as input, and returns NULL if any entry in the list is NULL.
        public IntPtr Noesis_AnimFromAnimsList;

        //new in Noesis 3.1
        //opens a file stream handle
        public IntPtr Noesis_FSOpen;
        //closes a file stream handle
        public IntPtr Noesis_FSClose;
        //get file size
        public IntPtr Noesis_FSGetSize;
        //seek
        public IntPtr Noesis_FSSeek;
        //get position
        public IntPtr Noesis_FSTell;
        //eof?
        public IntPtr Noesis_FSEOF;
        //reads from a file stream handle
        public IntPtr Noesis_FSRead;
        //write to a file stream handle
        public IntPtr Noesis_FSWrite;
        //guess the extension of a file based on its contents (currently fairly limited in possible results, will be expanding in the future)
        public IntPtr Noesis_GuessFileExt;

        //new in Noesis 3.15
        //generates smooth normals for the rpgeo context. should be called after all geometry has been added, but before rpgConstructModel.
        //resv MUST BE NULL. (may be utilized in future updates)
        public IntPtr rpgSmoothNormals;

        //new in Noesis 3.17
        //pixStride is expected to be 3 for rgb888 or 4 for rgba8888 data. desiredColors can be any number.
        //if useAlpha is true (and pixStride is 4), the alpha channel will be considered in the process.
        //the returned buffer will be in rgba8888 format (regardless of pixStride), and must be freed by Noesis_UnpooledFree.
        public IntPtr Image_GetMedianCut;

        //New in Noesis 3.26
        //opens a file stream in binary write mode, using the same path system as the above function. you are responsible for closing the file.
        //use Noesis_FSClose to close the file handle.
        public IntPtr Noesis_ExportArchiveFileOpen;

        //new in Noesis 3.27
        //functions similarly to LoadPairedFile, but returns a read-only file handle instead. The file must be closed with Noesis_FSClose
        //when you're done with it.
        public IntPtr Noesis_OpenPairedFile;

        //new in Noesis 3.28
        //calculates tangents (allocates a pooled buffer if tangents is NULL)
        //also triStride should be the size of a *triangle*, not the size of a single index.
        public IntPtr rpgCalcTangents;
        public IntPtr Noesis_ExportArchiveFileCheckExists;

        //new in Noesis 3.31
        //allocates a noesisTexFr_t for a texture
        public IntPtr Noesis_TexFrameInfoAlloc;

        //new in Noesis 3.46
        //gets the NPAPI_Register-returned index associated with the current type handler
        public IntPtr Noesis_GetTypeHandlerIdx;
        //creates a dds file in memory from dxt data and supplied parameters. dxtFmt can be NOESISTEX_DXT* or a FOURCC code.
        //you must free the non-null return pointer with Noesis_UnpooledFree.
        public IntPtr Image_CreateDDSFromDXTData;
        //same as above but with tga and rgba32 data
        //you must free the non-null return pointer with Noesis_UnpooledFree.
        public IntPtr Image_CreateTGAFromRGBA32;
        //you probably shouldn't use this unless you're me or you really know how things work internally
        public IntPtr rpgSetExData_LocalPool;
        //typically you will not want to call this function at all, as long as you pass back your created model(s) to noesis.
        //this call is dangerous and can also destroy data linked to the model if no other models are referencing it anymore (such as textures, materials, and anims)
        //you must also never call Noesis_FreeModels on a model before calling Noesis_FreeSharedModel on any shared models created from it.
        public IntPtr Noesis_FreeModels;
        //this only needs to be called if the shared model was created with NMSHAREDFL_LOCALPOOL
        public IntPtr Noesis_FreeSharedModel;
        //copies all mesh data off of shared model, so that the shared model can be safely freed/discarded afterward.
        //however, any material, animation, or external data pointed to be the shared model will only be pointed to be the noesis model, and should *not* be freed until the model itself is.
        public IntPtr Noesis_ModelFromSharedModel;
        //reads encoded 8-byte path name into wchar buffer (assumed dst is MAX_NOESIS_PATH long)
        public IntPtr Noesis_GetEncodedWidePath;
        //the deferred anim object should not be shared by any models, as it will be freed along with the rapi instance. always copy the deferred anim (and its data) off before using it.
        public IntPtr Noesis_SetDeferredAnim;
        public IntPtr Noesis_GetDeferredAnim;
        //assumes dst is MAX_NOESIS_PATH long
        public IntPtr Noesis_GetTypeExtension;

        //new in Noesis 3.5
        //tangents are expected to be 4 components, with the vector in the first 3 and bitangent sign (-1 or 1) in the 4th
        public IntPtr rpgVertTan4f;
        public IntPtr rpgVertTanX;
        public IntPtr rpgVertTan4us;
        public IntPtr rpgVertTan4s;
        public IntPtr rpgVertTan4hf;
        public IntPtr rpgBindTangentBuffer;
        //resv must be NULL
        public IntPtr rpgSmoothTangents;
        //use the RPGOPT_ flags with these functions
        public IntPtr rpgSetOption;
        public IntPtr rpgGetOption;

        //new in Noesis 3.52
        //attempts to load a texture on the given path (also tries input-relative paths), returns NULL if nothing was found.
        //automatically attempts to load the texure in all importable image formats.
        public IntPtr Noesis_LoadExternalTex;
        //sets the second-pass/lightmap material
        public IntPtr rpgSetLightmap;

        //new in Noesis 3.54
        //parses through a deflate stream to determine the final destination size
        public IntPtr Noesis_GetInflatedSize;

        //new in Noesis 3.55
        //loads a texture by matching the loading handler(s) to the given extension
        public IntPtr Noesis_LoadTexByHandler;

        //new in Noesis 3.59
        //performs an in-place ps2 twiddling. bpp (bits per pixel) must be 4 or 8.
        public IntPtr Noesis_TwiddlePS2;

        //new in Noesis 3.66
        public IntPtr rpgVertex3d;
        public IntPtr rpgVertNormal3d;
        public IntPtr rpgVertUV2d;
        public IntPtr rpgVertColor4d;
        public IntPtr rpgVertColor3d;
        public IntPtr rpgVertBoneWeightD;

        //new in Noesis 3.69
        public IntPtr Noesis_FilterFileName;
        public IntPtr Noesis_FilterFileNameW;

        //new in Noesis 3.7
        //provides a unified interface for pool-allocating bones
        //(this is a new version of the Noesis_AllocBones function which allocates the new bone structure)
        public IntPtr Noesis_AllocBones;

        //new in Noesis 3.72
        public IntPtr Decomp_LZHMelt;
        public IntPtr Noesis_GetLZHMeltSize;

        //new in Noesis 3.73
        public IntPtr rpgSetStripEnder;
        public IntPtr rpgGetStripEnder;

        //new in Noesis 3.84
        //for a typical xmemcompress'd stream, windowBits should be 17, resetInterval should be -1, and frameSize should be -1. (for LZX default)
        //returns -1 if failed, or actual size of decompressed data.
        public IntPtr Decomp_XMemLZX;

        //Image_GetTexRGBA will get you a buffer of raw RGBA32 data from a noesis texture.
        //=====IMPORTANT READ OR SMALL CHILDREN AND ANIMALS WILL DIE AS A RESULT OF YOUR NEGLIGENCE=====
        //IMPORTANT: if shouldFree comes back true, you must free the returned buffer with Noesis_UnpooledFree when you're done with it.
        //shouldFree will be false if the texture data is already in native rgba32 form, in this case you will simply be given a pointer
        //directly to the texture data buffer, and freeing that pointer would be a terrible world-ending thing to do. So don't do that.
        //=====IMPORTANT READ OR SMALL CHILDREN AND ANIMALS WILL DIE AS A RESULT OF YOUR NEGLIGENCE=====
        public IntPtr Image_GetTexRGBA;

        //new in Noesis 3.852
        public IntPtr Image_DecodePVRTC;

        //new in Noesis 3.97
        //grabs an interpolated sample from a rgba32 image. returns rgba colors as 4 floats in a 0.0-1.0 range in dst.
        public IntPtr Image_InterpolatedSample;
        //sets the module into global data mode and loads a file. this should only be invoked by tools, do not invoke it in format handlers or you will probably crash noesis.
        //use Noesis_FreeGData when you're done with the loaded data.
        public IntPtr Noesis_LoadGData;
        //frees global data.
        public IntPtr Noesis_FreeGData;
        //sets global data. same as LoadGData except this allows you to create the model yourself instead of loading from storage.
        public IntPtr Noesis_SetGData;
        //exports global data to file.
        public IntPtr Noesis_ExportGData;
        //gets the loaded model count
        public IntPtr Noesis_GetLoadedModelCount;
        //gets a loaded model.
        public IntPtr Noesis_GetLoadedModel;

        //new in Noesis 3.971
        //returns a gaussian-blurred rgba32 image from a source rgba32 image. the returned pointer must be freed with Noesis_UnpooledFree
        public IntPtr Image_GaussianBlur;

        //new in Noesis 3.98
        //functions the same as rpgCalcTangents, but converts a full tangent matrix to an array of tan4's
        public IntPtr rpgConvertTangents;

        //new in Noesis 3.99
        //if returned pointer is non-NULL, it must be freed with Noesis_UnpooledFree
        public IntPtr Noesis_DecompressEdgeIndices;
        //if vuMem points to a NULL pointer, it will be auto-allocated. auto-allocated vuMem must be freed with Noesis_UnpooledFree.
        //cbs may be NULL if no callback handlers are desired.
        public IntPtr Noesis_PS2_ProcessVIFCodes;
        //commits ps2 draw lists to the active rpg context and empties the draw list. provided material index should correspond to material name "mat%i" (where %i is the material index) and to a texture in the texList.
        //this is because uv's must be fit to texture dimensions.
        //bindBones acts as a map for vertex weights into a main bone list.
        //resv must be NULL.
        public IntPtr Noesis_PS2_RPGCommitLists;
        //gets the component index for a given chunk.
        public IntPtr Noesis_PS2_GetComponentIndex;
        //handles a chunk. may automatically call Noesis_PS2_RPGCommitLists, if a new primitive type is encountered.
        //parameters have the same meaning as with Noesis_PS2_RPGCommitLists.
        //chunkOfs must be the offset of a ps2GeoChunkHdr_t in the fileBuffer, and will automatically be incremented past the chunk as it's handled.
        //resv must be NULL.
        public IntPtr Noesis_PS2_RPGHandleChunk;

        //new in Noesis 3.991
        public IntPtr rpgGenerateStripListsEx;

        //new in Noesis 3.994
        //decodes and encodes raw image data from a format string. returned pointer must be freed with Noesis_UnpooledFree.
        //see python documentation for info on format string. (rapi.imageDecodeRaw)
        public IntPtr Noesis_ImageDecodeRaw;
        public IntPtr Noesis_ImageEncodeRaw;
        //tries reading a file relative to the path of the input file
        public IntPtr Noesis_InputReadFile; //you must free the pointer returned by Noesis_ReadFile with Noesis_UnpooledFree! (unless it's NULL)
        public IntPtr Noesis_InputReadFileW; //you must free the pointer returned by Noesis_ReadFile with Noesis_UnpooledFree! (unless it's NULL)
                                             //creates a bone map. returns the number of bones in the bonemap, and if bmap is non-null, it is filled in by a Noesis_UnpooledAlloc'd bone list
                                             //if bmap is non-null, the weight bone indices are modified in-place to reference the map.
        public IntPtr Noesis_CreateBoneMap; //if *bmap comes back non-null, it must be freed with Noesis_UnpooledFree

        //new in Noesis 3.996
        //returns -1 if no preview model loaded
        public IntPtr Noesis_GetSelectedPreviewModel;
        //queries time with highprecision performance counters
        public IntPtr Noesis_GetTimeMS;
        //functions the same as rpgTransformModel, but accepts base-relative matrices instead to be applied directly for skin transforms
        public IntPtr rpgSkinModel;
        //registers a button. rgbUp and rgbDown may be NULL to use the default user tool image. all resv parameters must be NULL.
        public IntPtr Noesis_RegisterUserButton;

        //new in Noesis 3.997
        //copies transformed verts from the internal model. returns true on success, false on failure. will fail if internal geometry is no longer identical to geometry in the shared model.
        public IntPtr Noesis_CopyInternalTransforms;

        //new in Noesis 4.0
        //sets an expression system variable
        public IntPtr Express_SetEVar;
        //sets an expression system function handler
        public IntPtr Express_SetUserFunc;
        //parses an expression
        public IntPtr Express_Parse;
        //evaluates an expression
        public IntPtr Express_Evaluate;
        //set the user-data pointer on an expression object
        public IntPtr Express_SetUserData;
        //get the user-data pointer
        public IntPtr Express_GetUserData;
        //get the original expression string
        public IntPtr Express_GetString;
        //allocate material expressions. resv must be NULL.
        public IntPtr Noesis_AllocMaterialExpressions;

        //new in Noesis 4.02
        public IntPtr Noesis_GetPRSSize;
        public IntPtr Decomp_PRS;

        //new in Noesis 4.04
        public IntPtr Noesis_ExportArchiveFileOpenEx;

        //new in Noesis 4.06
        //these function identically to their non-safe counterparts, but allow you to provide a buffersize.
        //when using rpgCommitTrianglesSafe instead of rpgCommitTriangles, indices will be bounds-checked against actual buffer sizes,
        //and the function will return a negative value if anything is out of bounds.
        public IntPtr rpgBindPositionBufferSafe;
        public IntPtr rpgBindNormalBufferSafe;
        public IntPtr rpgBindTangentBufferSafe;
        public IntPtr rpgBindUV1BufferSafe;
        public IntPtr rpgBindUV2BufferSafe;
        public IntPtr rpgBindColorBufferSafe;
        public IntPtr rpgBindBoneIndexBufferSafe;
        public IntPtr rpgBindBoneWeightBufferSafe;
        public IntPtr rpgFeedMorphTargetPositionsSafe;
        public IntPtr rpgFeedMorphTargetNormalsSafe;
        public IntPtr rpgCommitTrianglesSafe;

        //New in Noesis 4.074
        public IntPtr Noesis_AllocTexRefs;

        //New in Noesis 4.0781
        public IntPtr Image_DXT_RemoveFlatFractionBlocks;

        //New in Noesis 4.0783
        //boneRefMapSize is the number of entries in the bone reference map (not the size in bytes)
        public IntPtr rpgSetBoneMapSafe;

        //New in Noesis 4.079
        public IntPtr Noesis_TextureAllocEx;

        //New in Noesis 4.0799
        public IntPtr Image_InterpolatedSampleFloat;

        //New in Noesis 4.081
        //operates on the same scale as Noesis_GetTimeMS, but useful as a rendering timer.
        //this timer only increments once per frame, and should be used for time-based rendering since your rendering code may be called
        //more than once per frame for stereoscopic rendering.
        public IntPtr Noesis_GetFrameTime;
        public IntPtr Noesis_GetSplineSetBounds;
        public IntPtr Noesis_SplineLastOut;
        public IntPtr Noesis_SplineLastPos;
        //creates a mesh around a spline for simple visualization
        //for every returned pointer (pos, nrm, etc.) you must free it with Noesis_UnpooledFree.
        public IntPtr Noesis_SplineToMeshBuffers;
        //generates a normal map (rgba32) from a heightmap. (rgba32) r+b+g added together is used to specify height.
        //1.0 is a good default for both scale values. returned pointer must be Noesis_UnpooledFree'd.
        public IntPtr Image_NormalMapFromHeightMap;

        //New in Noesis 4.0828
        public IntPtr rpgUnifyBinormals;

        //New in Noesis 4.0836
        public IntPtr rpgActiveContextIsValid;

        //inflate/deflate with explicit window bits
        public IntPtr Decomp_Inflate2;
        public IntPtr Compress_Deflate2;
        public IntPtr Noesis_GetInflatedSize2;

        //New in Noesis 4.0843
        //this function operates on all vertices that have been committed from immediate mode or buffers (via rpgEnd or rpgCommitTriangles)
        //it does effectively the same thing as rpgSkinModel, but doesn't require a constructed shared model to operate.
        //param may be NULL.
        public IntPtr rpgSkinPreconstructedVertsToBones; //skins committed verts to bones

        //New in Noesis 4.0844
        //returns true if handler is being invoked for export instead of preview or instanced module data load
        public IntPtr Noesis_IsExporting;

        //New in Noesis 4.0863
        //rearranges image data in morton order
        public IntPtr Image_MortonOrder;

        //New in Noesis 4.0866
        //same as rpgAnimFromBonesAndMatsFinish, except it generates from a keyframed animation instead of matrices
        public IntPtr Noesis_AnimFromBonesAndKeyFramedAnim;

        //New in Noesis 4.087
        //rearranges image data in morton order
        //flags:
        //1 - toMorton
        //2 - swapXY
        //resv must be 0.
        public IntPtr Image_MortonOrderEx;

        //New in Noesis 4.0875
        public IntPtr rpgGetVertexCount;
        public IntPtr rpgGetTriangleCount;

        //New in Noesis 4.0897
        public IntPtr rpgGetMorphBase;
        public IntPtr rpgSetMorphBase;

        //New in Noesis 4.092
        public IntPtr Noesis_StrPoolGetOfsIfInPool;

        //New in Noesis 4.0955
        //swizzle 4-byte rgba pixel based on flags. resv must be 0 or no changes will occur to p.
        public IntPtr Noesis_SwizzleNormalPixEx;

        //New in Noesis 4.096
        //grabs a snapshot of internal mesh properties
        public IntPtr Noesis_GetMeshInternalProperties;

        //New in Noesis 4.0961
        public IntPtr Noesis_UntileImageRAWEx;
        public IntPtr Noesis_UntileImageDXTEx;

        //New in Noesis 4.0962
        public IntPtr Noesis_ConvertDXTEx;

        //New in Noesis 4.0965
        //provides user-named vertex data when using immediate mode.
        //if the data should be treated as per-instance (meaning it's set only once for a whole stream of verts),
        //use the RPGVUFLAG_PERINSTANCE flag.
        public IntPtr rpgVertUserData;
        //binds a user-named vertex buffer. dataSize is the entire size of the buffer, and dataElemSize is the per-vertex
        //data size, and dataStride is the number of bytes between elements in the buffer.
        //you can use a dataStride of 0 if you want to have a single chunk of data used for every vertex. (per-instance mode)
        //to unbind a user-named buffer, call rpgBindUserDataBuffer(name, NULL, 0, 0, 0, 0). to unbind all user-named buffers,
        //call rpgBindUserDataBuffer(NULL, NULL, 0, 0, 0, 0) or use rpgClearBufferBinds.
        //flags is currently unnecessary, as RPGVUFLAG_PERINSTANCE is indicated by a stride of 0. if RPGVUFLAG_PERINSTANCE is passed as a flag,
        //stride will be forced to 0.
        public IntPtr rpgBindUserDataBuffer;

        //New in Noesis 4.0968
        public IntPtr Noesis_SimulateDragAndDrop;

        //New in Noesis 4.0969
        //processes export commands
        public IntPtr Noesis_ProcessCommands;

        //New in Noesis 4.0974
        //under construction
        public IntPtr rpgWeldVerts;

        //New in Noesis 4.0977
        //returned pointer must be freed with Noesis_UnpooledFree. when freed, all data and stream pointers therein will also be invalidated.
        public IntPtr Noesis_DecompDefaultDrawSegs;
        public IntPtr Noesis_WritePCMWaveFile;

        //New in Noesis 4.098
        public IntPtr Noesis_DecodeADPCMBlock;
        public IntPtr Noesis_GetExportingModelSetCount;
        public IntPtr Noesis_GetExportingModel;

        public IntPtr rpgVertUniqueIndex;

        //pass NOESIS_PLUGINAPI_VERSION for apiVersion. this will allow future API revisions to return NULL if the M68000 API has been changed in a way
        //which breaks binary compatibility. resv must be NULL.
        public IntPtr Noesis_CreateM68000;
        public IntPtr Noesis_DestroyM68000;

        //New in Noesis 4.143
        //if return value is non-NULL, it should be freed via Noesis_UnpooledFree unless pDestData was provided.
        //if pDestData is provided, its size must be >= sourceElemCount * 3 or * 4 if wBits is non-0.
        //sourceElemStride specifies number of bytes between each source element (normal), sourceElemCount specifies total number of source elements.
        //each element's uint32 will be endian-swapped as it's processed if sourceIsBigEndian is true.
        //if nBits values are negative, source component will be treated as a signed fixed point value.
        //if nBits values are positive, source component will be treated as unsigned, then scale and biased (* 2 - 1) to -1..1.
        //returned data will be a 3 or 4 component array of normals of size sourceElemCount. 3 components if wBits is 0, otherwise 4.
        //xyz of returned values will be normalized. w value, if present, will be untouched.
        public IntPtr Noesis_DecodeNormals32;

        //New in Noesis 4.144
        //same as Image_GetTexRGBA, but returns HDR color data in the form of rgbaF128. values sourced from non-HDR formats
        //will be in the range of 0..1. HDR pixel data may contain any value.
        //if the return values is non-NULL and shouldFree is true, YOU MUST FREE THE POINTER with Noesis_UnpooledFree.
        public IntPtr Image_GetTexRGBAFloat;

        //pResvA/pResvB must be NULL. returns a pool-allocated HDR tex data structure.
        public IntPtr Noesis_AllocHDRTexStructure;

        //returns NULL outside of image export handlers, otherwise a pointer to the texture who owns the image data being written, if any.
        public IntPtr Noesis_GetTextureBeingWritten;

        //if return is non-NULL, must be freed with Noesis_UnpooledFree.
        //returned data will be in rgb48 instead of rgb24 form. it will be the caller's responsibility to scale/bias/interpret that data appropriately.
        public IntPtr Image_JPEG_ReadDirect;


        //lzo 1y
        public IntPtr Decomp_LZO_1y;

        //lzo 1x with buffer overrun checks
        public IntPtr Decomp_LZOSafe_1x;
        //lzo 1y with buffer overrun checks
        public IntPtr Decomp_LZOSafe_1y;

        public IntPtr Image_DecodePVRTCEx;

        public IntPtr Noesis_FillOutPCMWaveHeader;

        public IntPtr Decomp_LZ4;

        public IntPtr Image_InterpolatedSampleEx;

        public IntPtr Image_CreateDDSFromDXTDataEx;

        public IntPtr Image_GetTexRGBAOffset;
        public IntPtr Image_GetTexRGBAFloatOffset;

        public IntPtr Image_GetMipSize;

        //checks all texture and relative paths for a given file, and returns the file contents in a buffer if found. if non-NULL is returned, free with Noesis_UnpooledFree.
        public IntPtr Noesis_LoadFileOnTexturePaths;

        public IntPtr Noesis_SetModelCustomData;

        //accepts one of NOE_ENCODEDXT_* values as encodeType. dataPixelStride is the number of bytes between each pixel. pResv must be NULL. pSizeOut may be NULL if return size is not needed.
        //the dxt buffer that's returned must be freed via Noesis_UnpooledFree. the buffer will also be padding out for dxt block alignment if the source image dimensions are not aligned to
        //block size.
        //for NOE_ENCODEDXT_BC4, only the first 2 (red/green) channels are used to encode the 2 "alpha" blocks.
        public IntPtr Noesis_EncodeDXT;

        //typical filtering for mip generation. assumes rgba32 src/dst. if dstW != srcW/2 || dstH != srcH/2, or either dimension is not aligned to 2, falls back to ResampleImageBilinear.
        public IntPtr Noesis_ResampleImageBox;

        public IntPtr Noesis_GetMorphGroupInfoFromList;
        public IntPtr rpgSetExData_MorphGroups;

        //will be ecb if pIV is NULL.
        public IntPtr Decrypt_AES;
        public IntPtr Encrypt_AES;

        //does not require a valid rpg context (static call)
        public IntPtr rpgCalculateGenus;

        //does not require a valid rpg context (static call)
        //destType must be RPGEODATA_DOUBLE or RPGEODATA_FLOAT. pParamOut must be large enough to store (4 or 8) * 2 * vertexCount. returns < 0 on failure.
        public IntPtr rpgParameterize2D;

        public IntPtr Noesis_GetLZNT1Size;
        public IntPtr Decomp_LZNT1;

        public IntPtr Noesis_LoadTexByHandlerMulti;

        public IntPtr Noesis_ParseInstanceOptions;

        public IntPtr rpgSkinPreconstructedVertsToTransforms; //skins committed verts to bones

        //pPath should not include an extension, it will be selected by the target texture exporter
        public IntPtr Noesis_ExportTextureInDesiredFormat;

        public IntPtr Noesis_LoadTexturesForModelEx;

        public IntPtr Noesis_GetPreviewAngleTransform;

        public IntPtr Noesis_TurnAnimNameIntoAbsPath;

        public IntPtr Noesis_GetLeftHandedPreference;

        //this name is allowed to be duplicated between meshes, and is to be used as a guide by exporters for formats which support meshes with multiple materials.
        //in this case, the exporter may elect to re-group meshes sharing the same source name into a single mesh.
        public IntPtr rpgSetSourceName;

        //pResvA/pResvB must be NULL. returns a pool-allocated palette tex data structure.
        public IntPtr Noesis_AllocPalTexStructure;

        //returns NULL if there is no palette data attached to the texture.
        //Noesis_UnpooledFree must be used to free returned pointer if non-NULL.
        public IntPtr Noesis_GetTexPalRgba;

        //as above, but both ppPalOut and ppIndicesOut must be freed if function returns true;
        public IntPtr Noesis_GetTexPalIndicesRgba;

        public IntPtr rpgSetUVXScaleBias;

        //uvIndex 0 = "rpgBindUV1Buffer"
        //uvIndex 1 = "rpgBindUV2Buffer"
        //uvIndex 2+ = uvx buffers
        //elemCount will generally be 2 for "uv" coordinates, but up to 4 is allowed.
        public IntPtr rpgBindUVXBuffer;
        public IntPtr rpgBindUVXBufferSafe;

        //functions as Noesis_ExportTextureInDesiredFormat, but allows multiple textures for applicable formats. for non-applicable formats, only the first texture will be exported.
        //also supplies a pForceExt option, which if non-NULL, will override the export handler with a handler matching the given extension.
        public IntPtr Noesis_ExportTextureInDesiredFormatMulti;

        //pPalData and pPalIndices may each be NULL unless you want to write an 8-bit paletted png to memory.
        //return value >= 0 indicates success.
        public IntPtr Noesis_PNG_WriteToMemory;

        //handle with care, doesn't respect refcount and doesn't check shouldFreeData
        public IntPtr Noesis_ForceFreeTextureData;

        public IntPtr rpgFeedMorphName;

        //meant to be used with "GData" stuff
        public IntPtr Noesis_SetSelectedModel;

        //can be safely used to preserve pointer in module instance data through successive plugin calls, e.g. check -> load.
        //note that if calls aren't directly successive, data may be stomped by another plugin.
        public IntPtr Noesis_SetPluginUserPtr;
        public IntPtr Noesis_GetPluginUserPtr;
        //pointer to a scratch buffer meant to be preserved between plugin calls under a given instance
        public IntPtr Noesis_GetPluginUserScratchBuffer;

        //see TEXRGBAFLOAT_FLAG_* for flags
        public IntPtr Image_GetTexRGBAFloatWithFlags;

        //like the first version, but flags allows for different sample distributions
        public IntPtr Image_NormalMapFromHeightMapEx;

        //pResv should be NULL. this will be pool-allocated, no need to explicitly free or worry about attaching to a bone.
        public IntPtr Noesis_AllocBoneDebugInfo;

        //remap fraction with 3ds-style ease in/out
        public IntPtr Noesis_EaseInterpolationFraction;

        public IntPtr Noesis_BlinnPhongToBeckmann;
        public IntPtr Noesis_BeckmannToBlinnPhong;

        public IntPtr rpgConvertTangentsEx;

        public IntPtr Noesis_KF_DataCountForRotationType;
        public IntPtr Noesis_KF_DataCountForTranslationType;
        public IntPtr Noesis_KF_DataCountForScaleType;
        //that's right, i'm using erp
        public IntPtr Noesis_KF_ExtraDataCountForRotationAndErpType;
        public IntPtr Noesis_KF_ExtraDataCountForTranslationAndErpType;
        public IntPtr Noesis_KF_ExtraDataCountForScaleAndErpType;

        //resize with point filtering
        //flag bit 1 uses texel center instead of corner
        public IntPtr Noesis_ResampleImageNearest;

        //all 3 of these have been exposed through noesis_misc/NPAPI_GetUserExtProc for years now, but here are some stubs to make them more apparent.
        //dest is rgba32 * width * height * depth
        public IntPtr Image_DecodeASTC;
        //source is rgba32 * width * height * depth
        public IntPtr Image_EncodeASTC;
        //dest is rgba32 * width * height, pFmt can be: "R", "RG", "Rs", "RGs", "RGB", "RGB1", "sRGB", "RGBA", "sRGBA", "RGBA1", "sRGBA1"
        public IntPtr Image_DecodeETC;
        //dest should be widthInBlocks * heightInBlocks * blockSize bytes large, format corresponds to internal etcpack formats because this function is a lazy afterthought.
        //etc1/etc2/eac are all supported.
        public IntPtr Image_EncodeETC;

        //calculates a crc32 from partial data. the result is cached for the file currently being loaded, so subsequent calls to the same region will be a fast lookup.
        //returns false if the offset/size is out of range.
        public IntPtr Noesis_LastCheckedPartialChecksum;

        //linear-ordered blocks of 8x8 morton-ordered pixels. ordering is always done at the texel level, so if you're dealing with a <1BPP format, you can expand it and reorder the expanded data.
        public IntPtr Image_UntilePICA200Raw;
        public IntPtr Image_TilePICA200Raw;
        //linear-ordered blocks of 2x2 etc-blocks ("block" may include the 4-bit alphas for etc1a4). flags & 1 is provided as a convenience to endian-swap blocks as they come through.
        public IntPtr Image_UntilePICA200ETC;
        public IntPtr Image_TilePICA200ETC;
        //performs Image_UntilePICA200ETC with flags & 1, deinterleaves alpha, and performs Image_DecodeETC
        public IntPtr Image_DecodePICA200ETC;

        public IntPtr Noesis_CalculateCRC32;

        //AMD tiling/untiling routines use AMD's AddrLib, which is licensed under https://opensource.org/licenses/MIT - AddrLib is (c) 2007-2019 Advanced Micro Devices, Inc. All Rights Reserved.
        public IntPtr Image_UntileAMDR600;
        public IntPtr Image_TileAMDR600;

        //more stuff that was already exposed through extensions
        public IntPtr Image_UntileBlockLinearGOBs;
        public IntPtr Image_TileBlockLinearGOBs;
        //Image_TileCalculateBlockLinearGOBBlockHeight returns the block height, while both functions expect log2 of block height as inputs.
        //minHeightL2 should usually be 0, but varies per implementation (as does the whole selection algorithm, so this might not work with your target)
        public IntPtr Image_TileCalculateBlockLinearGOBBlockHeight;
        public IntPtr Image_BlockLinearGOBMaxBlockHeightForDefaultLayout;

        //noesis will call the appropriate callback function for the handler specified by this function, after the current handler function exits.
        //pOtherName should be the "typeDesc" used to register the other handler.
        //if non-NULL, pNewData should be a buffer allocated with Noesis_UnpooledAlloc.
        //this function should only be called from inside handler callback functions, and not more than once within a single callback.
        //pResv must be NULL.
        //if the function returns false, you're still responsible for freeing pNewData. otherwise, the function assumes ownership of the buffer.
        //some other notes:
        // - not supported for all handler callback types
        // - calling this within a check function will completely defer to the other format, meaning your other callback functions won't even be called when you defer
        // - be careful with data validation when calling this from a non-check handler - data validation for the format you've deferred to will not run when this is called inside of a load handler
        public IntPtr Noesis_DeferToOtherHandler;

        //as above with Image_UntileAMDR600 and Image_TileAMDR600, these routines use AMD's AddrLib
        public IntPtr Image_UntileAMDRDNA;
        public IntPtr Image_TileAMDRDNA;
        public IntPtr Image_CalculateAMDRDNAMipInfo;

        //getting/setting internal view data allows you to preserve view orientation across scene changes.
        //however, the internal data structures here are subject to occasional drastic changes.
        //this means you shouldn't try to be clever and try to do anything with the data itself, it's likely to break your plugin/script in the future.
        //serializing the data for later use is reasonable, but if you do this, be sure to check the result of Noesis_SetInternalViewData to see if the data is no longer valid for the current noesis version.
        public IntPtr Noesis_GetInternalViewDataSize;
        //dstSize must be >= Noesis_GetInternalViewDataSize(). returns true on success.
        public IntPtr Noesis_GetInternalViewData;
        //returns true on success.
        public IntPtr Noesis_SetInternalViewData;

        //some data may map to explicit transfer dimensions for PSMCT32, making the standard PS2 "untwiddle" function unusable.
        //to cope with that, this function allows writing as PSMCT32 using arbitrary dimensions and reading back at the given bit depth.
        public IntPtr Noesis_WriteAndReadbackPS2Explicit32;

        //the returned data pointer does not need to be freed, and is subject to processing from -paltransindex/-paltranscolor
        public IntPtr Image_InstancedCachedRgb24ToRgba32;
        public IntPtr Image_ClearInstancedCache;

        public IntPtr Noesis_ResampleImageBicubic;

        public IntPtr Noesis_ForcePreviewAnimUI;

        //reserved, do not call.
        public IntPtr resvA;
        public IntPtr resvB;
        public IntPtr resvC;
        public IntPtr resvD;
        public IntPtr resvE;
        public IntPtr resvF;
        public IntPtr resvG;
    }


    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct noePluginInfo_s
    {
        public fixed byte pluginName[64];
        public fixed byte pluginDesc[512];

        public fixed byte resv[512];
    }

    //BONE_STRUCT_VER = 0x246A0E06;
    //for feeding data back, only this structure and eData.parent matter.
    //IT IS VERY IMPORTANT THAT EACH BONE'S 'name' CONTAINS A UNIQUE STRING.
    //MAX_BONE_NAME_LEN = 128 //pushed from 32 to 128 for Noesis 3.7
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct modelBone_s
    {
        //ver is automatically set to the current BONE_STRUCT_VER when you call Noesis_AllocBones.
        //this is how noesis deals with changes to this bone structure while maintaining compatibility with old plugins.
        private int ver;

        //index will be filled in for you noesis-side.
        private int index;
        public fixed byte name[128];
        //plugins should just leave parentName blank and set eData.parent instead. parentName is set and used internally by pure-legacy code.
        public fixed byte parentName[128];
        //you need to fill in mat yourself when passing bone data to noesis - it's the modelspace (not parent-relative) bone matrix.
        public modelMatrix_s mat; //model_matrix_t

        public modelBoneExData_s eData; //modelBoneExData_t

        public int flags;
        public int userIndex;
#if WIN64
        public fixed long resv[6];
#endif
#if WIN32
        public fixed int resv[6];
#endif
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct modelBoneExData_s
    {
        public IntPtr parent;

        //ignore these fields, they're used internally be pure-legacy code
        IntPtr next;
        modelMatrix_s transMat;
        modelMatrix_s relativeMat;
        modelMatrix_s baseMat;
        modelMatrix_s transWithLenMat;
        private fixed short lastFrameAngles[3];

        //may eventually add extended data pointers, long name strings, etc.
#if WIN64
        public fixed long resv[4];
#endif
#if WIN32
        public fixed int resv[4];
#endif
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct modelMatrix_s
    {
        public Vector3 x1;
        public Vector3 x2;
        public Vector3 x3;
        public Vector3 o;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct noesisTexFr_s
    {
        public int ofsX;
        public int ofsY;
        public int frameIdx;
        public int viewType;

        public float rad;
        public int frameDelay;
#if WIN64
        public fixed long resv[15];
#endif
#if WIN32
        public fixed int resv[15];
#endif
    }

    public enum ENoeHdrTexFormat
    {
        kNHDRTF_RGB_F96 = 0,
        kNHDRTF_RGBA_F128,
        kNHDRTF_Lum_F32,
        kNHDRTF_RGBA_F64,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct SNoeHDRTexData
    {
        public void* pData;
        public nint dataLen;
        public ENoeHdrTexFormat hdrFormat;
        public int hdrFlags;
#if WIN64
        public fixed long resv[32];
#endif
#if WIN32
        public fixed int resv[32];
#endif
    }

    public enum ENoePalFormat
    {
        kNPF_RGB888 = 0,
        kNPF_RGBA8888,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct SNoePalData
    {
        public void* pData;
        public nint dataLen;
        public bool notDataOwner;//[NativeTypeName("bool")]
        public int colorCount;
        public ENoePalFormat palFormat;
        public int flags;
        public int transparentIndex;
        public void* pOriginalIndices;
        public int originalIndexBpp;
        public int originalWidth;
        public int originalHeight;
#if WIN64
        public fixed long resv[30];
#endif
#if WIN32
        public fixed int resv[30];
#endif
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct SNoeTexExtraData
    {
        public float mLodBias;
        public int mInternalFlags;
        public fixed int mInternalTracking[8];
#if WIN64
        public fixed long mResv[8];
#endif
#if WIN32
        public fixed int mResv[8];
#endif
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct noesisTex_s
    {
        public byte* filename;
        public int w;
        public int h;
        public int type;
        public byte* data;
        public nint dataLen;
        public int gltex;
        public int globalIdx;
        public int flags;
        public bool shouldFreeData;
        public int refCount;
        public noesisTexFr_s* frameInfo;
        public int mipCount;
        public fixed short unused[2];
        public SNoeHDRTexData* pHdr;
        public SNoePalData* pPal;
        public SNoeTexExtraData* pExtra;
#if WIN64
        public fixed long resv[2];
#endif
#if WIN32
        public fixed int resv[2];
#endif
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct noesisExtTexRef_s
    {
        public byte* diffuse;
        public byte* normal;
        public byte* specular;
        public byte* opacity;
        public byte* bump;
        public byte* env;
        public byte* occl;
#if WIN64
        public fixed long reserved[29];
#endif
#if WIN32
        public fixed int reserved[29];
#endif
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct noesisMatEx_s
    {
        public Vector4 envMapColor;
        public Vector4 ambientColor;
        public Vector4 blendedNormalFracs;

        public Vector3 rimColor;
        public float rimWidth;
        public float rimPow;
        public Vector3 rimOfs;
        public float rimBias;
        
        public fixed byte userTag[8];
        public void* userData;
        public int userDataSize;
        
        public float roughnessScale;
        public float roughnessBias;
        public float metalScale;
        public float metalBias;
        
        public float roughnessAnisoScale;
        public float roughnessAnisoAngle;

        public fixed int pbrGenTexIdx[8];
        
        public float* pUvScaleBias;
        public float* pUvPlanes;
        
        public float fresnelScale;
        
        public float* pSpecSwizzle;
        
        public int flags2;
        
        public int occlTexIdx;
        public float occlScale;
#if WIN64
        public fixed long resv[22];
#endif
#if WIN32
        public fixed int resv[22];
#endif
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct noesisMaterial_s
    {
        public byte* name;
        public bool skipRender;
        public Vector4 diffuse;
        public Vector4 specular;
        public bool noDefaultBlend;
        public int texIdx;
        public int extTex;

        public int blendSrc;
        public int blendDst;
        public float alphaTest;
        public bool noLighting;

        public int normalTexIdx;
        public int specularTexIdx;
        public int transTexIdx;
        public int obsoleteProgramIndex;

        public int flags;
        
        public int refCount;
        public noesisExtTexRef_s* extRefs;
        public noesisMaterial_s* nextPass;

        public noesisMatExpr_s* expr;
        
        public int bumpTexIdx;
        public int envTexIdx;

        public noesisMatEx_s* ex;
        public IntPtr mCustomData;
        public nint resv;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe partial struct noesisMatData_s
    {
        public noesisTex_s* textures;
        public int numTextures;

        public noesisMaterial_s* materials;
        public int numMaterials;
        public int refCount;
        public int internalFlags;
#if WIN64
        public fixed long resv[7];
#endif
#if WIN32
        public fixed int resv[7];
#endif
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct noesisMatExpr_s
    {
        //per-vertex expression evaluators

        //All of these are pointer arrays
        public IntPtr v_posExpr_0;
        public IntPtr v_posExpr_1;
        public IntPtr v_posExpr_2;

        public IntPtr v_nrmExpr_0;
        public IntPtr v_nrmExpr_1;
        public IntPtr v_nrmExpr_2;

        public IntPtr v_uvExpr_0;
        public IntPtr v_uvExpr_1;

        public IntPtr v_clrExpr_0;
        public IntPtr v_clrExpr_1;
        public IntPtr v_clrExpr_2;
        public IntPtr v_clrExpr_3;

        //global material expression evaluators
        public IntPtr diffuse_0;
        public IntPtr diffuse_1;
        public IntPtr diffuse_2;
        public IntPtr diffuse_3;

        public IntPtr specular_0;
        public IntPtr specular_1;
        public IntPtr specular_2;
        public IntPtr specular_3;

        public IntPtr uvTrans_0;
        public IntPtr uvTrans_1;
        public IntPtr uvTrans_2;

        public IntPtr uvRot_0;
        public IntPtr uvRot_1;
        public IntPtr uvRot_2;

        public IntPtr texIdx;
        public IntPtr normalTexIdx;
        public IntPtr specularTexIdx;

        public IntPtr resv_0; //16 slots
        public IntPtr resv_1; 
        public IntPtr resv_2; 
        public IntPtr resv_3;

        public IntPtr resv_4;
        public IntPtr resv_5;
        public IntPtr resv_6;
        public IntPtr resv_7;

        public IntPtr resv_8;
        public IntPtr resv_9;
        public IntPtr resv_10;
        public IntPtr resv_11;

        public IntPtr resv_12;
        public IntPtr resv_13;
        public IntPtr resv_14;
        public IntPtr resv_15;
    }

    public enum rpgeoPrimType_e
    {
        RPGEO_NONE = 0,
        RPGEO_POINTS,
        RPGEO_TRIANGLE,
        RPGEO_TRIANGLE_STRIP,
        RPGEO_QUAD, //ABC_DCB
        RPGEO_POLYGON,
        RPGEO_TRIANGLE_FAN,
        RPGEO_QUAD_STRIP,
        RPGEO_TRIANGLE_STRIP_FLIPPED,
        RPGEO_QUAD_ABC_BCD,
        RPGEO_QUAD_ABC_ACD,
        RPGEO_QUAD_ABC_DCA,
        NUM_RPGEO_TYPES
    }

    public enum rpgeoDataType_e
    {
        RPGEODATA_FLOAT = 0,
        RPGEODATA_INT,
        RPGEODATA_UINT,
        RPGEODATA_SHORT,
        RPGEODATA_USHORT,
        RPGEODATA_HALFFLOAT,
        RPGEODATA_DOUBLE,
        RPGEODATA_BYTE,
        RPGEODATA_UBYTE,
        NUM_RPGEO_DATATYPES
    }

    public struct CArrayList
    {
        public IntPtr m_array;
    }
}