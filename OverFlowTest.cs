/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 1993-2006 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/VS.NET2005/FnsComposite/OverFlowTest.cs 2     4/17/07 3:41p John.gwynn $ */
using System;
using System.Collections;
using NUnit.Framework;

namespace FnsComposite
{
	/// <summary>
	/// 
	/// </summary>
	[TestFixture]
	public class OverFlowTest
	{
		public OverFlowTest()
		{
		}
		[Test,Ignore] public void TestOverfow() 
		{
			OverFlow myOverflowBase = new OverFlow("0");
			OverFlow myOverflow = new OverFlow("10");

			myOverflow.AttributeName = "CLAIM:CLAIM_TYPE";
			myOverflow.Caption = "    Claim (C) or Occurence (O)?";
			Assert.IsFalse(myOverflow.ShowWhenEmpty);
			myOverflow.Sequence = 10;
			myOverflow.CaptionLength = 40;

			myOverflowBase.Add(myOverflow);

			myOverflow = new OverFlow("20");
			Assert.IsFalse(myOverflow.ShowWhenEmpty);
			myOverflow.Sequence = 20;
			myOverflow.CaptionLength = 40;

			myOverflowBase.Add(myOverflow);

			string strXml = myOverflowBase.ToString();
			Assert.IsTrue(strXml.Length > 0);

			Console.WriteLine("{0}",strXml);
			Console.WriteLine("{0}",myOverflowBase.ToXml());
		}
		[Test, Ignore] public void TestOverfowSet() 
		{
			OverFlow myOverflow = OverflowSet.BuildOverflowSet("11","PAU");
			Console.WriteLine("************** GetAttributeDescriptions()");
			Console.WriteLine(myOverflow.GetAttributeDescriptions());
			Console.WriteLine("************** Overflow ToSting()");

			Assert.IsNotNull(myOverflow);
			string strXml = myOverflow.ToString();
			Assert.IsTrue(strXml.Length > 0);

			//Console.WriteLine("{0}",strXml);
			//Console.WriteLine("{0}",myOverflow.ToXml());

			IEnumerator enumList = myOverflow.GetEnumerator();
			while(enumList.MoveNext())
			{
				OverFlow currentOver = (OverFlow)enumList.Current;
				Console.WriteLine("{0}",currentOver.ToString());
			}
		}
	}
}
/*
 * $Log: /SourceCode/Components/VS.NET2005/FnsComposite/OverFlowTest.cs $
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 5     9/08/06 2:04p John.gwynn
 * Build modifications [Unit tests]
 * 
 * 4     4/09/06 8:15p John.gwynn
 * FxCop and Resharper reformatting changes
 * 
 * 3     1/15/06 8:09p John.gwynn
 * finalized overflow attribute structure
 * 
 * 2     1/07/06 7:33p John.gwynn
 * added overflow iterator (sorted by default)
 */
