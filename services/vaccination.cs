using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealtClinic.Services;

public class vaccination : VeterinarianService
{
    public vaccination() : base("Vaccination") { }

    public override void Attend()
    {
        Console.WriteLine("Applying vaccination to the pet...");
    }

}
