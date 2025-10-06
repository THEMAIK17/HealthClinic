using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic.Services;

public class GeneralConsultation : VeterinarianService
{

    public GeneralConsultation() : base("General Consultation") { }

    public override void Attend()
    {
        Console.WriteLine("Performing a general consultation for the pet...");
    }



}
