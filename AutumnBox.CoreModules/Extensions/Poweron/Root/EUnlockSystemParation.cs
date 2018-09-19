﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/13 9:33:21 (UTC +8:00)
** desc： ...
*************************************************/
using AutumnBox.Basic.Calling.Adb;
using AutumnBox.Basic.Device;
using AutumnBox.OpenFramework.Extension;
using System.Threading;

namespace AutumnBox.CoreModules.Extensions.Poweron.Root
{
    [ExtName("[ROOT]解锁系统分区")]
    [ExtName("[ROOT]Unlock system paration", Lang = "en-US")]
    [ExtRequiredDeviceStates(DeviceState.Poweron)]
    [ExtRequireRoot]
    [ExtIcon("Icons.key.png")]
    public class EUnlockSystemParation : OfficialVisualExtension
    {
        protected override int VisualMain()
        {
            new AdbCommand(TargetDevice, $"root")
                .To(OutputPrinter)
                .Execute();
            Thread.Sleep(300);
            var result = new AdbCommand(TargetDevice, $"disable-verity")
                .To(OutputPrinter)
                .Execute();
            return result.ExitCode;
        }
    }
}
