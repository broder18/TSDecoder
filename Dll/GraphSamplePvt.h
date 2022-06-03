#pragma once

#include "LibGraph\LibGraph.h"

#include "Defines.h"
#include <tchar.h>
#include <dshow.h>
#include <atlbase.h>
#include <initguid.h>
#include <dvdmedia.h>
#include <bdaiface.h>

#include "Interfaces\UDPLocalSource.h"
#include "Interfaces\IUDPLocalSourceCtrl.h"
#include "Interfaces\IUDPStatistics.h"
#include "Interfaces\RTPSource.h"
#include "Interfaces\IUDPStatistics.h"
#include "Interfaces\IPMTPvtDataSettings.h"

#define BUFANDSIZE(x)       x, (sizeof(x) / sizeof((x)[0]))
#define EXPORT              __declspec(dllexport) __stdcall

#include "IOStructs.h"

class GRAPH_CONTROL : public CGraph
{
    /* local port used to connect RTPSource and UDPLocalSource */
    WORD LocalPort;

    /* link between the actual renderer window and its parent window */
    //RENDERERMAP RendererMap;
    map<HWND, CComPtr<IVideoWindow>> RendererMap;
    map<int, CComPtr<IPMTPvtDataSettings>> pIPMTPvtDataSettings;
    //CComPtr<IPMTPvtDataSettings> pIPMTPvtDataSettings;

    void AddUDPLocalSource();
    void AddRTPSource(INPUT_NETWORK *pInNet);
    void AddDemuxRefact(PIDS *Pids);
    void AddDemuxPin(WORD Pid, int Idx);
    void AddVideoDecoderRefact();
    void AddFFDSHOWDecoder(LPCTSTR VideoDecoderName, LPCTSTR outputId);
    void AddLAVDecoder(LPCTSTR VideoDecoderName, LPCTSTR outputId);
    void AddVideoRendererRefact(HCONTAINER_WND *hWindows);
    void ConnectRenderer(LPCTSTR VideoDecoderName, LPCTSTR VideoRendererName, HWND hContainerWnd);
    void SetupRendererRefact(HWND hContainerWnd) const;
    void AddPMTPvtData();
    
    void ConnectPMTPvtData(LPCTSTR PMTPvtDataName, LPCTSTR PinNameOut, LPCTSTR VideoRendererName, int PMTRendererID);

public:
    GRAPH_CONTROL() : LocalPort{ 0 } 
    {
    }

    void SetRTPSource(INPUT_NETWORK* pInNet);
    void BuildGraphRefact(GS_SETTINGSRefact *pSettings);
    void PlaceRendererRefact(HWND hContainerWnd) const;
    void GetStatistics(PIDSTATISTICS *pStat);
    void ResetStatistics();
};

typedef GRAPH_CONTROL *PGRAPH_CONTROL;

void __declspec(noreturn) THROW(const char *pErrMsg);
