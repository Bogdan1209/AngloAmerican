using AngloAmerican.Common.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AngloAmerican.Common.Utils
{
    public class MyBeautifulMapper: IMyBeautifulMapper
    {
        public IEnumerable<TChild> Map<TParent, TChild>(IEnumerable<TParent>parents)
            where TParent : class
            where TChild : class, new()
        {
            var children = new List<TChild>();
            foreach(var parent in parents)
            {
                children.Add(Map<TParent, TChild>(parent));
            }

            return children;
        }

        public TChild Map<TParent, TChild>(TParent parent)
            where TParent : class
            where TChild : class, new()
        {
            try
            {
                TChild child = new TChild();

                var parentType = parent.GetType();
                var childType = child.GetType();

                var parentProperties = parent.GetType().GetProperties();
                var childProperties = child.GetType().GetProperties();

                foreach (var parentProperty in parentProperties)
                {
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name
                            && parentProperty.PropertyType == childProperty.PropertyType)
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }

                return child;
            }
            catch(Exception ex)
            {
                //Log(ex)
                throw;
            }
           
        }
    }

}
