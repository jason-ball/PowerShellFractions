using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace PowerShellFractions
{
    [Cmdlet(VerbsCommon.New, "Fraction")]
    [OutputType(typeof(Fraction))]
    public class AddFractionCmdlet: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        public int Numerator { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public int Denominator { get; set; }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            WriteObject(new Fraction(Numerator, Denominator));
        }
    }
}
