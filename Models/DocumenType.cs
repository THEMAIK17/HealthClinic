using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic.Models;

public class DocumenType
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Unique ID for each document type
    public string DocumentName { get; set; }             


    public DocumenType(string documentName)
    {
        DocumentName = documentName;
    }
}
