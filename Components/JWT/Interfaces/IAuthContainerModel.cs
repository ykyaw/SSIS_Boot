using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

/**
 * @author WUYUDING
 */
namespace SSIS_BOOT.Components.JWT.Interfaces
{
    public interface IAuthContainerModel
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }

        Claim[] Claims { get; set; }
    }
}
