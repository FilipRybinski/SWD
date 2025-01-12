using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Utils
{
    public static class SmileUtils
    {
        public static void AttachLicense()
        {
            new Smile.License(
                "SMILE LICENSE 82f9b2d9 d2d4eb60 670da835 " +
                "THIS IS AN ACADEMIC LICENSE AND CAN BE USED " +
                "SOLELY FOR ACADEMIC RESEARCH AND TEACHING, " +
                "AS DEFINED IN THE BAYESFUSION ACADEMIC " +
                "SOFTWARE LICENSING AGREEMENT. " +
                "Serial #: 33agawfnbls1invp7z4shj4re " +
                "Issued for: Filip Rybi\u0144ski (rybciaw77@gmail.com) " +
                "Academic institution: Politechnika Bia\u0142ostocka " +
                "Valid until: 2025-07-15 " +
                "Issued by BayesFusion activation server",
                new byte[] {
                0x2b,0x48,0xe7,0xd2,0xfc,0x39,0x05,0x75,0xa6,0x9f,0x89,0x9c,0xde,0xeb,0x22,0x15,
                0xb6,0x95,0xc7,0x5e,0x62,0xf1,0xc8,0xbc,0x44,0x7d,0xf6,0xae,0xb8,0x46,0xf2,0x3c,
                0x55,0x38,0x3c,0xcc,0x53,0x94,0xca,0x80,0x24,0xbe,0xd4,0x11,0xc5,0x9b,0x1e,0xc2,
                0x82,0xd6,0xae,0xdf,0xba,0x8f,0x2c,0xeb,0x06,0xe7,0x41,0x60,0x74,0x9a,0x76,0xd1
                }
            );
        }
    }
}