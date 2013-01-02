using System.Drawing.Printing;

namespace ETrains.Utilities
{
    public class PrinterChecking
    {
        public static bool IsValid (string printerName)
        {

                bool retVal = false;
                try
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings.PrinterName = printerName;
                    retVal = pd.PrinterSettings.IsValid;
                }
                catch (System.Exception ex)
                {
                    retVal = false;
                }
                return retVal;
            }
        
    }
}
