using Xunit;

namespace Reference.Semantics
{
    public class TestRefSemantics
    {
        [Fact]
        public void Struct_return_value_is_a_copy()
        {
            // ARRANGE
            var myloc = new MyLocation(new MyPoint(1, 1));

            // ACT
            MyPoint p = myloc.GetLocation();
            /* Update the copied value */
            p.X = 2;

            // ASSERT
            Assert.Equal(2, p.X);
            Assert.Equal(1, myloc.GetLocation().X);
        }

        [Fact]
        public void Ref_return_value_is_a_copy()
        {
            // ARRANGE
            var myloc = new MyLocation(new MyPoint(1, 1));

            // ACT

            /* Since we don't have "ref" keywords, the ref return will be COPIED to variable P */
            MyPoint p = myloc.GetLocationByRef();
            p.X = 2;

            // ASSERT
            Assert.Equal(2, p.X);
            Assert.Equal(1, myloc.GetLocationByRef().X);
        }

        [Fact]
        public void Ref_return_value_is_not_copy()
        {
            // ARRANGE
            var myloc = new MyLocation(new MyPoint(1, 1));

            // ACT

            ref MyPoint p = ref myloc.GetLocationByRef();
            p.X = 2;

            // ASSERT
            Assert.Equal(2, p.X);
            Assert.Equal(2, myloc.GetLocationByRef().X);
        }

        [Fact]
        public void Assign_value_to_ref_method()
        {
            // ARRANGE
            var myloc = new MyLocation(new MyPoint(1, 1));

            // ACT
            /* This is a strange one. Normally, we are not able to assign a value to a method like this. */
            myloc.GetLocationByRef() = new MyPoint(2, 2);

            // ASSERT
            Assert.Equal(2, myloc.GetLocationByRef().X);
        }

        public class MyLocation
        {
            private MyPoint _location;

            public MyLocation(MyPoint location)
            {
                _location = location;
            }

            public MyPoint GetLocation()
            {
                return _location;
            }

            public ref MyPoint GetLocationByRef()
            {
                return ref _location;
            }
        }

        public struct MyPoint
        {
            public float X;
            public float Y;

            public MyPoint(float x, float y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
