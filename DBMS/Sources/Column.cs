using System;
using System.Collections.Generic;
using System.Text;

namespace DBMS.src
{
    public class Column
    {
        public string name { get; set; }
        // public CustomType type { get; set; }
        public string customTypeName { get; set; }

        public override bool Equals(object obj)
        {
            var otherColumn = obj as Column;
            if (obj == null)
            {
                return false;
            }
            else
            {
                return name == otherColumn.name && customTypeName == otherColumn.customTypeName;
            }
        }
        
        public void SetName(string newName)
        {
            name = newName;
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2) ^ name.Length;
        }

        public Column()
        {
            name = "";
           // type = new CustomInteger();
            customTypeName = "Integer";
        }
        
        public Column(string _name, string _customTypeName)
        {
            name = _name;
           // type = ChooseType(_customTypeName);
            customTypeName = _customTypeName;
        }
        
        public bool EvaluateType(string value)
        {
            // var customType = (CustomType)type;
            return TypesValidator.IsValidValue(customTypeName, value); //customType.isValidValue(value);
        }

        public string GetName()
        {
            return name;
        }

       /* private CustomType ChooseType(string customTypeName)
        {
            CustomType type;
            switch (customTypeName)
            {
                case "Integer":
                    type = new CustomInteger();
                    break;
                case "Real":
                    type = new CustomReal();
                    break;
                case "Char":
                    type = new CustomChar();
                    break;
                case "String":
                    type = new CustomString();
                    break;
                case "Picture":
                    type = new CustomPNG();
                    break;
                case "RealInvl":
                    type = new CustomRealInvl();
                    break;
                default:
                    type = new CustomString();
                    break;
            }
            return type;
        }
       */
    }
}
