#ifndef _IOSTRUCTS_H
#define _IOSTRUCTS_H

#include <PshPack4.h>

typedef struct tagINPUT_NETWORK
{
    DWORD MulticastIP;
    WORD MulticastPort;
} INPUT_NETWORK;

typedef struct tagHCONTAINER_WND
{
    HWND hContainerWnd0;
    HWND hContainerWnd1;
    HWND hContainerWnd2;
    HWND hContainerWnd3;
    HWND hContainerWnd4;
} HCONTAINER_WND;

typedef struct tagPIDS
{
    WORD pid0;
    WORD pid1;
    WORD pid2;
    WORD pid3;
    WORD pid4;
} PIDS;

typedef struct tagGS_SettingsRefact
{
    DWORD Size;
    INPUT_NETWORK InNet;
    HCONTAINER_WND hWnd;
    PIDS V_Pids;
} GS_SETTINGSRefact;

#include <PopPack.h>

#endif