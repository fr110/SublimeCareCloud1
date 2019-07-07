using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMessages
{
    public static class MsgTextCollection
    {
        public static Dictionary<string, string> MsgsList = new Dictionary<string, string>
        {
            //party
            { "P01", "Party Information is Saved Successfully!" },
            { "P02", "Party Information is Updated Successfully!" },
            { "I03", "Item with the same name or with same item barcode already exists. Please change and try agian." },
            { "I02", "Item Information is Updated Successfully!" },
            { "I01", "Item Information is Saved Successfully!" },
            { "DP01", "Parties List" },
            // Docotr 
            { "DOC01", "Docotor Information is Saved Successfully!" },
            { "DOC02", "Docotor Information is Updated Successfully!" },
            { "DOC03", "Investigation is deleted and Doctor information Updated Successfully!" },

            // for account user of doctor

            {"M_D01DEC","Account Created By System for Doctor." },
            {"M_D02DEC","Account Created By System for Doctor." },
            // for appointment
            {"AOC01", "Appointment Created By System for Doctor." },
            {"P_A001", "Patient Account Is Created By System" + DateTime.Now .ToShortDateString()}


        };
    }
}
