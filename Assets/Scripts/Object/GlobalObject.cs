using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalObject{

	static private DesignerAR designerAR;

	static public void SetDesignerAR(DesignerAR ar){
		designerAR = ar;
	}

	static public DesignerAR GetDesignerAR(){
		return designerAR;
	}

}
