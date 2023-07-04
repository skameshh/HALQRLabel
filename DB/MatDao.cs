using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HALQRLabel.DB
{
    public class MatDao
    {
        //SELECT [DLVRY_NBR],[DLVRY_ITM],a.[MTRL_NBR],[SHRT_TXT] as [Mat_Desc],[BTCH_NBR],[PLNT] ,b.GRS_WT,b.WT_UOM_CD 

        public string DeliveryNum { set; get; }
        public string DeliveryItem { set; get; }
        public string MaterialNum { set; get; }
        public string OldMaterialNum { set; get; }
        public string MaterialDesc { set; get; }
        public string MaterialRev { set; get; }
        public string BatchNum { set; get; }
        public string Plant { set; get; }
        public Decimal GrossWeight { set; get; }
        public string WeightUnit { set; get; }
        public int TotOrdQty { set; get; }
    }
}
