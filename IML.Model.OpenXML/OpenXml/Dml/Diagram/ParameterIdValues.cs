using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ParameterId")]
  public enum ParameterIdValues
  {
    [EnumString("horzAlign")]
    HorzAlign,
    [EnumString("vertAlign")]
    VertAlign,
    [EnumString("chDir")]
    ChDir,
    [EnumString("chAlign")]
    ChAlign,
    [EnumString("secChAlign")]
    SecChAlign,
    [EnumString("linDir")]
    LinDir,
    [EnumString("secLinDir")]
    SecLinDir,
    [EnumString("stElem")]
    StElem,
    [EnumString("bendPt")]
    BendPt,
    [EnumString("connRout")]
    ConnRout,
    [EnumString("begSty")]
    BegSty,
    [EnumString("endSty")]
    EndSty,
    [EnumString("dim")]
    Dim,
    [EnumString("rotPath")]
    RotPath,
    [EnumString("ctrShpMap")]
    CtrShpMap,
    [EnumString("nodeHorzAlign")]
    NodeHorzAlign,
    [EnumString("nodeVertAlign")]
    NodeVertAlign,
    [EnumString("fallback")]
    Fallback,
    [EnumString("txDir")]
    TxDir,
    [EnumString("pyraAcctPos")]
    PyraAcctPos,
    [EnumString("pyraAcctTxMar")]
    PyraAcctTxMar,
    [EnumString("txBlDir")]
    TxBlDir,
    [EnumString("txAnchorHorz")]
    TxAnchorHorz,
    [EnumString("txAnchorVert")]
    TxAnchorVert,
    [EnumString("txAnchorHorzCh")]
    TxAnchorHorzCh,
    [EnumString("txAnchorVertCh")]
    TxAnchorVertCh,
    [EnumString("parTxLTRAlign")]
    ParTxLTRAlign,
    [EnumString("parTxRTLAlign")]
    ParTxRTLAlign,
    [EnumString("shpTxLTRAlignCh")]
    ShpTxLTRAlignCh,
    [EnumString("shpTxRTLAlignCh")]
    ShpTxRTLAlignCh,
    [EnumString("autoTxRot")]
    AutoTxRot,
    [EnumString("grDir")]
    GrDir,
    [EnumString("flowDir")]
    FlowDir,
    [EnumString("contDir")]
    ContDir,
    [EnumString("bkpt")]
    Bkpt,
    [EnumString("off")]
    Off,
    [EnumString("hierAlign")]
    HierAlign,
    [EnumString("bkPtFixedVal")]
    BkPtFixedVal,
    [EnumString("stBulletLvl")]
    StBulletLvl,
    [EnumString("stAng")]
    StAng,
    [EnumString("spanAng")]
    SpanAng,
    [EnumString("ar")]
    Ar,
    [EnumString("lnSpPar")]
    LnSpPar,
    [EnumString("lnSpAfParP")]
    LnSpAfParP,
    [EnumString("lnSpCh")]
    LnSpCh,
    [EnumString("lnSpAfChP")]
    LnSpAfChP,
    [EnumString("rtShortDist")]
    RtShortDist,
    [EnumString("alignTx")]
    AlignTx,
    [EnumString("pyraLvlNode")]
    PyraLvlNode,
    [EnumString("pyraAcctBkgdNode")]
    PyraAcctBkgdNode,
    [EnumString("pyraAcctTxNode")]
    PyraAcctTxNode,
    [EnumString("srcNode")]
    SrcNode,
    [EnumString("dstNode")]
    DstNode,
    [EnumString("begPts")]
    BegPts,
    [EnumString("endPts")]
    EndPts,
  }
}
