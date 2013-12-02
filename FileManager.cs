using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace XNATable
{
    public class FileManager
    {
        LoadType type;
        List<string> tempAttributes;
        List<string> tempContents;
       
        enum LoadType { Attributes, Contents };
        bool identifierFound = false;

        public void LoadContent(string filename, List<List<string>> attributes,
            List<List<string>> contents)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Contains("Load="))
                    {
                        tempAttributes = new List<string>();
                        line = line.Remove(0, line.IndexOf("=") + 1);
                        type = LoadType.Attributes;
                    }
                    else
                    {
                        type = LoadType.Contents;
                    }

                    tempContents = new List<string>();

                    string[] lineArray = line.Split(']');

                    foreach (string li in lineArray)
                    {
                        string newLine = li.Trim('[', ' ', ']');
                        if (newLine != String.Empty)
                        {
                            if (type == LoadType.Contents)
                                tempContents.Add(newLine);
                            else
                                tempAttributes.Add(newLine);
                        }
                    }
                    if (type == LoadType.Contents && tempContents.Count > 0)
                    {
                        contents.Add(tempContents);
                        attributes.Add(tempAttributes);
                    }
                }
            }
        }

        public void LoadContent(string filename, List<List<string>> attributes,
            List<List<string>> contents, string identifier)
        {
            //Reading from textfiles
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //Check for EndLoad before Load
                    //Load is part of EndLoad
                    if(line.Contains("Endload=") && line.Contains(identifier))
                    {
                        identifierFound = false;
                        break;
                    }
                    else if (line.Contains("Load=") && line.Contains(identifier))
                    {
                        identifierFound = true;
                        continue;
                    }

                    if (identifierFound)
                    {
                        //If Load is found inside textfile, 
                        //load attributes of the kind until EndLoad
                        if (line.Contains("Load="))
                        {
                            tempAttributes = new List<string>();
                            line.Remove(0, line.IndexOf("=") + 1);
                            type = LoadType.Attributes;
                        }
                        else
                        {
                            tempContents = new List<string>();
                            type = LoadType.Contents;
                        }

                        string[] lineArray = line.Split(']');

                        foreach (string li in lineArray)
                        {
                            //trim the datastream
                            string newLine = li.Trim('[', ' ', ']');
                            if (newLine != String.Empty)
                            {
                                if (type == LoadType.Contents)
                                    tempContents.Add(newLine);
                                else
                                    tempAttributes.Add(newLine);
                            }
                        }
                        if (type == LoadType.Contents && tempContents.Count > 0)
                        {
                            contents.Add(tempContents);
                            attributes.Add(tempAttributes);
                        }
                    }
                }
            }

        }
    }
}
