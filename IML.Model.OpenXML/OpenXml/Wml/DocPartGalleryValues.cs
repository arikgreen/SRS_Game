using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DocPartGallery")]
  public enum DocPartGalleryValues
  {
    [EnumString("placeholder")]
    Placeholder = 0,
    [EnumString("any")]
    Any = 1,
    [EnumString("default")]
    Default = 2,
    [EnumString("docParts")]
    DocParts,
    [EnumString("coverPg")]
    CoverPg,
    [EnumString("eq")]
    Eq,
    [EnumString("ftrs")]
    Ftrs,
    [EnumString("hdrs")]
    Hdrs,
    [EnumString("pgNum")]
    PgNum,
    [EnumString("tbls")]
    Tbls,
    [EnumString("watermarks")]
    Watermarks,
    [EnumString("autoTxt")]
    AutoTxt,
    [EnumString("txtBox")]
    TxtBox,
    [EnumString("pgNumT")]
    PgNumT,
    [EnumString("pgNumB")]
    PgNumB,
    [EnumString("pgNumMargins")]
    PgNumMargins,
    [EnumString("tblOfContents")]
    TblOfContents,
    [EnumString("bib")]
    Bib,
    [EnumString("custQuickParts")]
    CustQuickParts,
    [EnumString("custCoverPg")]
    CustCoverPg,
    [EnumString("custEq")]
    CustEq,
    [EnumString("custFtrs")]
    CustFtrs,
    [EnumString("custHdrs")]
    CustHdrs,
    [EnumString("custPgNum")]
    CustPgNum,
    [EnumString("custTbls")]
    CustTbls,
    [EnumString("custWatermarks")]
    CustWatermarks,
    [EnumString("custAutoTxt")]
    CustAutoTxt,
    [EnumString("custTxtBox")]
    CustTxtBox,
    [EnumString("custPgNumT")]
    CustPgNumT,
    [EnumString("custPgNumB")]
    CustPgNumB,
    [EnumString("custPgNumMargins")]
    CustPgNumMargins,
    [EnumString("custTblOfContents")]
    CustTblOfContents,
    [EnumString("custBib")]
    CustBib,
    [EnumString("custom1")]
    Custom1 = 33,
    [EnumString("custom2")]
    Custom2 = 34,
    [EnumString("custom3")]
    Custom3 = 35,
    [EnumString("custom4")]
    Custom4 = 36,
    [EnumString("custom5")]
    Custom5 = 37,
  }
}
