using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExamples
{
    class O
    {
        // O - Open for Extension, Closed for Modification

        class BadO
        {
            int Type;

            // Adding new type requires modification of class (adding new if block)
            void Add()
            {
                if (Type == 0)
                {
                    // do something for type 0
                }
                else
                {
                    // do something for type 1
                }
            }
        }

        class GoodO
        {
            protected virtual void Add()
            {
                // do something for type 0
            }
        }

        class GoodOType1 : GoodO
        {
            protected override void Add()
            {
                // do something for type 1
            }
        }

        class GoodOType2 : GoodO
        {
            // When we added new type we extended code, but did not modify original class
            protected override void Add()
            {
                // do something for type 2
            }
        }
    }
}
