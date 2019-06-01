using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class BigNumberHandler : MonoBehaviour
{
	private int magicNumber = 4;

	// For extended display
	private List<string> longSuffixes = new List<string> { " ", " thousand", " million", " billion", " trillion", " quadrillion", " quintillion", " sextillion", " septillion", " octillion", " nonillion" };
	private List<string> prefixesLong = new List<string> { "", "un", "duo", "tre", "quattuor", "quin", "sex", "septen", "octo", "novem" };
	private List<string> suffixesLong = new List<string> { "decillion", "vigintillion", "trigintillion", "quadragintillion", "quinquagintillion", "sexagintillion", "septuagintillion", "octogintillion", "nonagintillion" };

	// For shortened display
	private List<string> truncSuffixes = new List<string> { "", "k", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No" };
	private List<string> prefixes = new List<string> { "", "Un", "Do", "Tr", "Qa", "Qi", "Sx", "Sp", "Oc", "No" };
	private List<string> suffixes = new List<string> { "D", "V", "T", "Qa", "Qi", "Sx", "Sp", "O", "N" };


	private void Start()
	{
		for(int i = 0; i < suffixes.Count - 1; i++)
		{
			for(int j = 0; j < prefixes.Count - 1; j++)
			{
				truncSuffixes.Add(prefixes[j] + suffixes[i]);
			}
		}

		truncSuffixes[11] = "Dc";

		for(int i = 0; i < suffixesLong.Count - 1; i++)
		{
			for(int j = 0; j < prefixesLong.Count - 1; j++)
			{
				longSuffixes.Add(prefixesLong[j] + suffixesLong[i]);
			}
		}
	}

	

	// Used for formatting the number to a readable format.
	public string GetResourceString(double value, bool isLong)
	{
		string startStr = value.ToString("n0");
		string str = Regex.Replace(startStr, "[@,]", string.Empty);

		if(str.Length < 4)
			return str;

		int val = (GetModulo(str) > 0) ? GetModulo(str) : (str.Length > 3) ? 3 : str.Length;

		string first = str.Substring(0, (str.Length > val) ? val : str.Length);
		str = str.Remove(0, (str.Length > val) ? val : str.Length);

		if(str.Length <= 0)
			return first;

		string decimal3 = str.Substring(0, (str.Length > 3) ? 3 : str.Length);
		str = str.Remove(0, (str.Length > 3) ? 3 : str.Length);

		string decimalNumbers = "," + decimal3;

		while(true)
		{
			if(decimalNumbers.Length <= 0)
				break;

			if(decimalNumbers.Substring(decimalNumbers.Length - 1) == "0" || decimalNumbers.Substring(decimalNumbers.Length - 1) == ",")
				decimalNumbers = decimalNumbers.Substring(0, decimalNumbers.Length - 1);
			else
				break;
		}

		return first + decimalNumbers + GetSuffix(Mathf.FloorToInt(startStr.Length / magicNumber), isLong);
	}

	

	public int GetModulo(string str)
	{
		int returnVal = str.Length % 3;

		int num = Mathf.FloorToInt(str.Length / magicNumber);
		int maxVal = truncSuffixes.Count - 1 * magicNumber;

		if(num > truncSuffixes.Count - 1)
		{
			returnVal = str.Length - maxVal;
		}

		return returnVal;
	}


	public string GetSuffix(int num, bool isLong)
	{
		if(num > truncSuffixes.Count - 1)
			return (isLong)? longSuffixes[truncSuffixes.Count - 1]:truncSuffixes[truncSuffixes.Count - 1];

		return (isLong) ? longSuffixes[num] : truncSuffixes[num];
	}
}
