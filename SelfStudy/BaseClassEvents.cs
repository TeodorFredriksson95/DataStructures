using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SelfStudy
{
    //Learning more about events and how to declare events in a base class which can be raised from derived classes
    public class WeaponEventArgs: EventArgs
    {
        public float Damage;
        public WeaponEventArgs(float damage)
        {
            Damage = damage;
        }
    }
    public abstract class Weapon
    {
        protected float _damage;
        public float Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public event EventHandler<WeaponEventArgs> WeaponDamageChanged;

        public abstract void DoDamage();

        protected virtual void OnWeaponDamageChanged(WeaponEventArgs e)
        {
            WeaponDamageChanged?.Invoke(this, e);
        }
    }

    public class SlingShot: Weapon
    {
        public SlingShot(float damage)
        {
            _damage = damage;
        }

        protected override void OnWeaponDamageChanged(WeaponEventArgs e)
        {
            base.OnWeaponDamageChanged(e);
        }

        public void UpdateWeaponDamage(float damage)
        {
            _damage = damage;
            OnWeaponDamageChanged(new WeaponEventArgs(damage));
        }

        public override void DoDamage()
        {
            Console.WriteLine("Did " + _damage + " damage!");
        }
    }

    public class Bazooka : Weapon
    {
        public Bazooka(float damage)
        {
            _damage = damage;
        }
        protected override void OnWeaponDamageChanged(WeaponEventArgs e)
        {
            base.OnWeaponDamageChanged(e);
        }

        public void UpdateWeaponDamage(float damage)
        {
            _damage = damage;
            OnWeaponDamageChanged(new WeaponEventArgs(damage));
        }

        public override void DoDamage()
        {
            Console.WriteLine($"Did {_damage} damage!");
        }
    }

    public class WieldedWeapon
    {
        private readonly List<Weapon> _weapons;

        public WieldedWeapon()
        {
            _weapons = new List<Weapon>();
        }

        public void AddWeapon(Weapon weapon)
        {
            _weapons.Add(weapon);

            weapon.WeaponDamageChanged += HandleWeaponDamageChanged;
        }

        private void HandleWeaponDamageChanged(object sender, WeaponEventArgs e)
        {
            if (sender is Weapon weapon)
            {
                Console.WriteLine($"Received event. Weapon damage is now {e.Damage}");

                weapon.DoDamage();
            }
        }
    }



    // Special EventArgs class to hold information about Shapes.
    public class ShapeEventArgs : EventArgs
    {
        public double NewArea;

        public ShapeEventArgs(double area)
        {
            NewArea = area;
        }
    }

    // Base class event publisher
    public abstract class Shape
    {
        protected double _area;
        
        public double Area
        {
            get => _area;
            set => _area = value;
        }

        // The event. Because we're using the generic EventHandler<T> event type
        // we don't need to declare a separate delegate type.
        public event EventHandler<ShapeEventArgs> ShapeChanged; // What would it look like if we didnt use the generic EventHandler<T> event type? Explore this

        // Remember that abstract methods force derived classes to define the implementation, while virtual methods provide a default implementation
        // which *can* but overriden, but is optional.
        public abstract void Draw();

        // The event-invoking method that derived classes can override.
        // Remember that protected means that derived classes can access the member, but other classes cannot.
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            ShapeChanged?.Invoke(this, e);
        }
    }

    public class Circle: Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
            _area = _radius * _radius * 3.14;
        }

        public void Update(double d)
        {
            _radius = d;
            _area = _radius * _radius * 3.14;
            OnShapeChanged(new ShapeEventArgs(_area));
        }

        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            // Here we can perform circle-specific processing before using our base event class to raise the event.
            base.OnShapeChanged(e); // Calls the base class event invocation method.s
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }

    public class Rectangle: Shape
    {
        private double _length;
        private double _width;

        public Rectangle(double length, double width)
        {
            _length = length;
            _width = width;
            _area = _length * _width;
        }

        public void Update(double length, double width)
        {
            _length = length;
            _width = width;
            _area = _length * _width;
            OnShapeChanged(new ShapeEventArgs(_area));
        }

        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            // Do rectangle specific operations here

            base.OnShapeChanged(e); // Call the base class event invocation method.
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle.");
        }
    }

    // Represents the surface on which the shapes are drawn.
    // Subscribes to shape events so that it knows when to redraw a shape.
    public class ShapeContainer
    {
        private readonly List<Shape> _list;

        public ShapeContainer()
        {
            _list = new List<Shape>();
        }
        
        public void AddShape(Shape shape)
        {
            _list.Add(shape);

            // Subscribe to the base class event.
            shape.ShapeChanged += HandleShapeChanged;
        }

        private void HandleShapeChanged(object sender, ShapeEventArgs e)
        {
            if (sender is Shape shape)
            {
                // Diagnostic message for demonstration purposes.
                Console.WriteLine("Received event. Shape area is now " + e.NewArea);

                shape.Draw();
            }
        }
    }

    public class EventsTest
    {
        public static void Main()
        {
            // Create the event publishers and subcriber
            Circle circle = new Circle(25);
            Rectangle rectangle = new Rectangle(40, 20);
            ShapeContainer container = new ShapeContainer();

            // Add shapes to container
            container.AddShape(circle);
            container.AddShape(rectangle);

            // The following will raise the base event
            circle.Update(15);
            rectangle.Update(10, 5);


            // Create weapons
            SlingShot sh = new SlingShot(20);
            Bazooka bz = new Bazooka(99);
            WieldedWeapon ww = new WieldedWeapon();

            ww.AddWeapon(sh);
            ww.AddWeapon(bz);

            // Raise the event
            sh.UpdateWeaponDamage(15);
            bz.UpdateWeaponDamage(9999);
        }
    }
}
