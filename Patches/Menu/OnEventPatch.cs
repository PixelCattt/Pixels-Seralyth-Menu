/*
 * Seralyth Menu  Patches/Menu/AntiKick.cs
 * A community driven mod menu for Gorilla Tag with over 1000+ mods
 *
 * Copyright (C) 2026  Seralyth Software
 * https://github.com/Seralyth/Seralyth-Menu
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.Linq;
using HarmonyLib;
using Photon.Pun;
using Seralyth.Extensions;

namespace Seralyth.Patches.Menu
{
    [HarmonyPatch(typeof(PhotonNetwork), nameof(PhotonNetwork.OnEvent))]
    public class AntiKick
    {
        public static bool enabled;

        public static bool Prefix()
        {
            if (enabled)
            {
                if (VRRigCache.ActiveRigs.All(rig => rig != null && rig.GetPing() > 500))
                    return false;
            }
            return true;
        }
    }
}
