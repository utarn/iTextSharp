/*
 * $Id: $
 *
 * This file is part of the iText (R) project.
 * Copyright (c) 1998-2012 1T3XT BVBA
 * Authors: VVB, Bruno Lowagie, et al.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License version 3
 * as published by the Free Software Foundation with the addition of the
 * following permission added to Section 15 as permitted in Section 7(a):
 * FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY 1T3XT,
 * 1T3XT DISCLAIMS THE WARRANTY OF NON INFRINGEMENT OF THIRD PARTY RIGHTS.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU Affero General Public License for more details.
 * You should have received a copy of the GNU Affero General Public License
 * along with this program; if not, see http://www.gnu.org/licenses or write to
 * the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
 * Boston, MA, 02110-1301 USA, or download the license from the following URL:
 * http://itextpdf.com/terms-of-use/
 *
 * The interactive user interfaces in modified source and object code versions
 * of this program must display Appropriate Legal Notices, as required under
 * Section 5 of the GNU Affero General Public License.
 *
 * In accordance with Section 7(b) of the GNU Affero General Public License,
 * a covered work must retain the producer line in every PDF that is created
 * or manipulated using iText.
 *
 * You can be released from the requirements of the license by purchasing
 * a commercial license. Buying such a license is mandatory as soon as you
 * develop commercial activities involving the iText software without
 * disclosing the source code of your own applications.
 * These activities include: offering paid services to customers as an ASP,
 * serving PDFs on the fly in a web application, shipping iText with a closed
 * source product.
 *
 * For more information, please contact iText Software Corp. at this
 * address: sales@itextpdf.com
 */

using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.tool.xml.svg.graphic;

namespace iTextSharp.tool.xml.svg.tags {

    public class LineTag : AbstractGraphicProcessor {
	    static String X1 = "x1";
	    static String Y1 = "y1";
	    static String X2 = "x2";	
	    static String Y2 = "y2";
    	
	    private float GetAttribute(String name, IDictionary<String, String> attributes){
		    float value = 0;
		    try{
                if (attributes.ContainsKey(name)) {
                    value = int.Parse(attributes[name]);
                }
		    }catch {
			    //do nothing
		    }
		    return value;
	    }
    		
	    public override IList<IElement> End(IWorkerContext ctx, Tag tag,
				    IList<IElement> currentContent) {
    		
		    IDictionary<String, String> attributes = tag.Attributes;
		    if(attributes != null){
			    IList<IElement> l = new List<IElement>(1);
	    	    l.Add(new Line(GetAttribute(X1, attributes), GetAttribute(Y1, attributes), 
	    			    GetAttribute(X2, attributes), GetAttribute(Y2, attributes), tag.CSS));
	    	    return l;
		    } else {
			    return new List<IElement>(0);
		    }        
	    }
    	
	    public override bool IsElementWithId() {
		    return true;
	    }
    }
}
