using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Object = Iml.Foundation.Object;

namespace Iml.Documentation
{
  //==========================================================================================
  /// <summary>
  /// Klasa rejestrująca sposoby numerowania w dokumencie
  /// </summary>
  public partial class Numbering
  {
      /// <summary>
      /// Pole przechowujące listę numerowań abstrakcyjnych
      /// </summary>
      private AbstractNumList fAbstract;

      /// <summary>
      /// Pole przechowujące listę instancji numerowania
      /// </summary>
      private NumberingInstanceList fInstances;

      /// <summary>
      /// 
      /// </summary>
      public AbstractNumList AbstractNums {
          get
          {
              if (fAbstract == null)
                  fAbstract = new AbstractNumList();
              return fAbstract;
          }
          set
          {
              fAbstract = value;
          }
      }

      /// <summary>
      /// 
      /// </summary>
      public NumberingInstanceList NumInstances
      {
          get
          {
              if (fInstances == null)
                  fInstances = new NumberingInstanceList();
              return fInstances;
          }
          set
          {
              fInstances = value;
          }
      }
  }
}
