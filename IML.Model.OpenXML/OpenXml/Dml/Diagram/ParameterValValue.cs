using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Union]
  [Alias("ParameterVal")]
  public struct ParameterValValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private ParameterValValue (HorizontalAlignmentValues value)
    {
      this.value = value;
    }

    public HorizontalAlignmentValues AsHorizontalAlignmentValues
    {
      get
      {
        return (HorizontalAlignmentValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (HorizontalAlignmentValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator HorizontalAlignmentValues (ParameterValValue value)
    {
      return (HorizontalAlignmentValues)value.value;
    }

    private ParameterValValue (VerticalAlignmentValues value)
    {
      this.value = value;
    }

    public VerticalAlignmentValues AsVerticalAlignmentValues
    {
      get
      {
        return (VerticalAlignmentValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (VerticalAlignmentValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator VerticalAlignmentValues (ParameterValValue value)
    {
      return (VerticalAlignmentValues)value.value;
    }

    private ParameterValValue (ChildDirectionValues value)
    {
      this.value = value;
    }

    public ChildDirectionValues AsChildDirectionValues
    {
      get
      {
        return (ChildDirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (ChildDirectionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator ChildDirectionValues (ParameterValValue value)
    {
      return (ChildDirectionValues)value.value;
    }

    private ParameterValValue (ChildAlignmentValues value)
    {
      this.value = value;
    }

    public ChildAlignmentValues AsChildAlignmentValues
    {
      get
      {
        return (ChildAlignmentValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (ChildAlignmentValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator ChildAlignmentValues (ParameterValValue value)
    {
      return (ChildAlignmentValues)value.value;
    }

    private ParameterValValue (SecondaryChildAlignmentValues value)
    {
      this.value = value;
    }

    public SecondaryChildAlignmentValues AsSecondaryChildAlignmentValues
    {
      get
      {
        return (SecondaryChildAlignmentValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (SecondaryChildAlignmentValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator SecondaryChildAlignmentValues (ParameterValValue value)
    {
      return (SecondaryChildAlignmentValues)value.value;
    }

    private ParameterValValue (LinearDirectionValues value)
    {
      this.value = value;
    }

    public LinearDirectionValues AsLinearDirectionValues
    {
      get
      {
        return (LinearDirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (LinearDirectionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator LinearDirectionValues (ParameterValValue value)
    {
      return (LinearDirectionValues)value.value;
    }

    private ParameterValValue (SecondaryLinearDirectionValues value)
    {
      this.value = value;
    }

    public SecondaryLinearDirectionValues AsSecondaryLinearDirectionValues
    {
      get
      {
        return (SecondaryLinearDirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (SecondaryLinearDirectionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator SecondaryLinearDirectionValues (ParameterValValue value)
    {
      return (SecondaryLinearDirectionValues)value.value;
    }

    private ParameterValValue (StartingElementValues value)
    {
      this.value = value;
    }

    public StartingElementValues AsStartingElementValues
    {
      get
      {
        return (StartingElementValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (StartingElementValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator StartingElementValues (ParameterValValue value)
    {
      return (StartingElementValues)value.value;
    }

    private ParameterValValue (BendPointValues value)
    {
      this.value = value;
    }

    public BendPointValues AsBendPointValues
    {
      get
      {
        return (BendPointValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (BendPointValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator BendPointValues (ParameterValValue value)
    {
      return (BendPointValues)value.value;
    }

    private ParameterValValue (ConnectorRoutingValues value)
    {
      this.value = value;
    }

    public ConnectorRoutingValues AsConnectorRoutingValues
    {
      get
      {
        return (ConnectorRoutingValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (ConnectorRoutingValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator ConnectorRoutingValues (ParameterValValue value)
    {
      return (ConnectorRoutingValues)value.value;
    }

    private ParameterValValue (ArrowheadStyleValues value)
    {
      this.value = value;
    }

    public ArrowheadStyleValues AsArrowheadStyleValues
    {
      get
      {
        return (ArrowheadStyleValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (ArrowheadStyleValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator ArrowheadStyleValues (ParameterValValue value)
    {
      return (ArrowheadStyleValues)value.value;
    }

    private ParameterValValue (ConnectorDimensionValues value)
    {
      this.value = value;
    }

    public ConnectorDimensionValues AsConnectorDimensionValues
    {
      get
      {
        return (ConnectorDimensionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (ConnectorDimensionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator ConnectorDimensionValues (ParameterValValue value)
    {
      return (ConnectorDimensionValues)value.value;
    }

    private ParameterValValue (RotationPathValues value)
    {
      this.value = value;
    }

    public RotationPathValues AsRotationPathValues
    {
      get
      {
        return (RotationPathValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (RotationPathValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator RotationPathValues (ParameterValValue value)
    {
      return (RotationPathValues)value.value;
    }

    private ParameterValValue (CenterShapeMappingValues value)
    {
      this.value = value;
    }

    public CenterShapeMappingValues AsCenterShapeMappingValues
    {
      get
      {
        return (CenterShapeMappingValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (CenterShapeMappingValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator CenterShapeMappingValues (ParameterValValue value)
    {
      return (CenterShapeMappingValues)value.value;
    }

    private ParameterValValue (NodeHorizontalAlignmentValues value)
    {
      this.value = value;
    }

    public NodeHorizontalAlignmentValues AsNodeHorizontalAlignmentValues
    {
      get
      {
        return (NodeHorizontalAlignmentValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (NodeHorizontalAlignmentValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator NodeHorizontalAlignmentValues (ParameterValValue value)
    {
      return (NodeHorizontalAlignmentValues)value.value;
    }

    private ParameterValValue (NodeVerticalAlignmentValues value)
    {
      this.value = value;
    }

    public NodeVerticalAlignmentValues AsNodeVerticalAlignmentValues
    {
      get
      {
        return (NodeVerticalAlignmentValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (NodeVerticalAlignmentValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator NodeVerticalAlignmentValues (ParameterValValue value)
    {
      return (NodeVerticalAlignmentValues)value.value;
    }

    private ParameterValValue (FallbackDimensionValues value)
    {
      this.value = value;
    }

    public FallbackDimensionValues AsFallbackDimensionValues
    {
      get
      {
        return (FallbackDimensionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (FallbackDimensionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator FallbackDimensionValues (ParameterValValue value)
    {
      return (FallbackDimensionValues)value.value;
    }

    private ParameterValValue (TextDirectionValues value)
    {
      this.value = value;
    }

    public TextDirectionValues AsTextDirectionValues
    {
      get
      {
        return (TextDirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (TextDirectionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator TextDirectionValues (ParameterValValue value)
    {
      return (TextDirectionValues)value.value;
    }

    private ParameterValValue (PyramidAccentPositionValues value)
    {
      this.value = value;
    }

    public PyramidAccentPositionValues AsPyramidAccentPositionValues
    {
      get
      {
        return (PyramidAccentPositionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (PyramidAccentPositionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator PyramidAccentPositionValues (ParameterValValue value)
    {
      return (PyramidAccentPositionValues)value.value;
    }

    private ParameterValValue (PyramidAccentTextMarginValues value)
    {
      this.value = value;
    }

    public PyramidAccentTextMarginValues AsPyramidAccentTextMarginValues
    {
      get
      {
        return (PyramidAccentTextMarginValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (PyramidAccentTextMarginValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator PyramidAccentTextMarginValues (ParameterValValue value)
    {
      return (PyramidAccentTextMarginValues)value.value;
    }

    private ParameterValValue (TextBlockDirectionValues value)
    {
      this.value = value;
    }

    public TextBlockDirectionValues AsTextBlockDirectionValues
    {
      get
      {
        return (TextBlockDirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (TextBlockDirectionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator TextBlockDirectionValues (ParameterValValue value)
    {
      return (TextBlockDirectionValues)value.value;
    }

    private ParameterValValue (TextAnchorHorizontalValues value)
    {
      this.value = value;
    }

    public TextAnchorHorizontalValues AsTextAnchorHorizontalValues
    {
      get
      {
        return (TextAnchorHorizontalValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (TextAnchorHorizontalValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator TextAnchorHorizontalValues (ParameterValValue value)
    {
      return (TextAnchorHorizontalValues)value.value;
    }

    private ParameterValValue (TextAnchorVerticalValues value)
    {
      this.value = value;
    }

    public TextAnchorVerticalValues AsTextAnchorVerticalValues
    {
      get
      {
        return (TextAnchorVerticalValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (TextAnchorVerticalValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator TextAnchorVerticalValues (ParameterValValue value)
    {
      return (TextAnchorVerticalValues)value.value;
    }

    private ParameterValValue (TextAlignmentValues value)
    {
      this.value = value;
    }

    public TextAlignmentValues AsTextAlignmentValues
    {
      get
      {
        return (TextAlignmentValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (TextAlignmentValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator TextAlignmentValues (ParameterValValue value)
    {
      return (TextAlignmentValues)value.value;
    }

    private ParameterValValue (AutoTextRotationValues value)
    {
      this.value = value;
    }

    public AutoTextRotationValues AsAutoTextRotationValues
    {
      get
      {
        return (AutoTextRotationValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (AutoTextRotationValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator AutoTextRotationValues (ParameterValValue value)
    {
      return (AutoTextRotationValues)value.value;
    }

    private ParameterValValue (GrowDirectionValues value)
    {
      this.value = value;
    }

    public GrowDirectionValues AsGrowDirectionValues
    {
      get
      {
        return (GrowDirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (GrowDirectionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator GrowDirectionValues (ParameterValValue value)
    {
      return (GrowDirectionValues)value.value;
    }

    private ParameterValValue (FlowDirectionValues value)
    {
      this.value = value;
    }

    public FlowDirectionValues AsFlowDirectionValues
    {
      get
      {
        return (FlowDirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (FlowDirectionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator FlowDirectionValues (ParameterValValue value)
    {
      return (FlowDirectionValues)value.value;
    }

    private ParameterValValue (ContinueDirectionValues value)
    {
      this.value = value;
    }

    public ContinueDirectionValues AsContinueDirectionValues
    {
      get
      {
        return (ContinueDirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (ContinueDirectionValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator ContinueDirectionValues (ParameterValValue value)
    {
      return (ContinueDirectionValues)value.value;
    }

    private ParameterValValue (BreakpointValues value)
    {
      this.value = value;
    }

    public BreakpointValues AsBreakpointValues
    {
      get
      {
        return (BreakpointValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (BreakpointValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator BreakpointValues (ParameterValValue value)
    {
      return (BreakpointValues)value.value;
    }

    private ParameterValValue (OffsetValues value)
    {
      this.value = value;
    }

    public OffsetValues AsOffsetValues
    {
      get
      {
        return (OffsetValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (OffsetValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator OffsetValues (ParameterValValue value)
    {
      return (OffsetValues)value.value;
    }

    private ParameterValValue (HierarchyAlignmentValues value)
    {
      this.value = value;
    }

    public HierarchyAlignmentValues AsHierarchyAlignmentValues
    {
      get
      {
        return (HierarchyAlignmentValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (HierarchyAlignmentValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator HierarchyAlignmentValues (ParameterValValue value)
    {
      return (HierarchyAlignmentValues)value.value;
    }

    private ParameterValValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get
      {
        return (Int32)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (Int32 value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator Int32 (ParameterValValue value)
    {
      return (Int32)value.value;
    }

    private ParameterValValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get
      {
        return (Double)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (Double value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator Double (ParameterValValue value)
    {
      return (Double)value.value;
    }

    private ParameterValValue (Boolean value)
    {
      this.value = value;
    }

    public Boolean AsBoolean
    {
      get
      {
        return (Boolean)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (Boolean value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator Boolean (ParameterValValue value)
    {
      return (Boolean)value.value;
    }

    private ParameterValValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get
      {
        return (String)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (String value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator String (ParameterValValue value)
    {
      return (String)value.value;
    }

    private ParameterValValue (ConnectorPointValues value)
    {
      this.value = value;
    }

    public ConnectorPointValues AsConnectorPointValues
    {
      get
      {
        return (ConnectorPointValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ParameterValValue (ConnectorPointValues value)
    {
      return new ParameterValValue(value);
    }

    public static implicit operator ConnectorPointValues (ParameterValValue value)
    {
      return (ConnectorPointValues)value.value;
    }

  }
}
