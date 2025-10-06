using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic.Services;

public abstract class VeterinarianService
{

    public string ServiceName { get; set; }

    public VeterinarianService(string serviceName)
    {
        ServiceName = serviceName;

    }

    public abstract void Attend();
    
        

}
