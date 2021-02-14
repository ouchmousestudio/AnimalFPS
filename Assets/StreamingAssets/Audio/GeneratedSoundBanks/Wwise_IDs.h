/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID AMMO_PICKUP = 4253579710U;
        static const AkUniqueID ARCTICAMB = 1640085587U;
        static const AkUniqueID DESERTAMB = 3681418210U;
        static const AkUniqueID FIRE_GUN = 336971538U;
        static const AkUniqueID FIRE_SHOTGUN = 626438066U;
        static const AkUniqueID HEALTH_PICKUP = 3731941266U;
        static const AkUniqueID PORTAL = 3118032615U;
        static const AkUniqueID START_MUSIC = 540993415U;
        static const AkUniqueID STOPALL = 3086540886U;
        static const AkUniqueID WATER_SPLASH = 1294445356U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace BOSS
        {
            static const AkUniqueID GROUP = 1560169506U;

            namespace STATE
            {
                static const AkUniqueID HASENDED = 3881786689U;
                static const AkUniqueID HASSTARTED = 31648514U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID NOTSTARTED = 2918396911U;
            } // namespace STATE
        } // namespace BOSS

        namespace PLAYER_LIFE
        {
            static const AkUniqueID GROUP = 3762137787U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace PLAYER_LIFE

    } // namespace STATES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SOUNDFX = 2810670744U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
