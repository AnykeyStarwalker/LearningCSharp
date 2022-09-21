using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lesson11_winform
{
    
    public abstract class Animal
    {
        public string state { get; set; }
        public string name { get; set; }
        public double eat { get; set; }
        public double happy { get; set; }
        public int age { get; set; }

        public int backXcoord = -1228; //168 to -1228

        public char Vector;
        public int Speed;
        public int Timer;
        public Bitmap skin = Resource1.isus, 
                background = Resource1.isus;
        public void Init()
        {
            this.state = "alife";
            this.eat = 100;
            this.happy = 100;
            this.age = 0;
            this.Vector = '#';
            this.Speed = 10;
            this.Timer = 10;
        }

    }
    public class Mammalis : Animal //млекопитающее
    {
        public void Update(Dictionary<string, bool> state)
        {
            if (this.state == "alife")
            {
                skin = Resource1.smallPig;
                background = Resource1.back;
                if (state["Right_Down"])
                {
                    if (backXcoord > -1280) 
                    { 
                    this.skin = Resource1.smallPig_Right;
                    this.backXcoord -= 10;
                    }
                }
                if (state["Left_Down"])
                {
                    if (backXcoord < 182)
                    {
                        this.skin = Resource1.smallPig_Left;
                        this.backXcoord += 10;
                    }
                }
                if (state["B_Down"])
                {
                    if( 180 > backXcoord & backXcoord > 80)
                    {
                        this.state = "grow";
                    }
                    if (-180 > backXcoord & backXcoord > -360)
                    {
                        this.state = "eat";
                    }
                    if (-650 > backXcoord & backXcoord > -830)
                    {
                        this.state = "fun";
                    }
                    if (-1150 > backXcoord & backXcoord > -1300)
                    {
                        this.state = "fate";
                    }
                }
                if (state["A_Down"])
                {

                }

                if (this.eat > 0)
                {
                    this.eat -= 0.1;
                }
                else
                {
                    this.state = "dead";
                    this.eat = 0;
                    this.happy = 0;
                }
                if (this.happy > 0)
                {
                    this.happy -= 0.1;
                }
                else
                {
                    this.state = "dead";
                    this.eat = 0;
                    this.happy = 0;
                }
            }
            if(this.state == "dead")
            {
                this.skin = Resource1.smallPig_Death;
            }
            if(this.state == "eat")
            {
                if (this.Timer > 0)
                {
                    if (this.eat < 99)
                    {
                        this.skin = Resource1.eat_32x32;
                        this.eat += 1;
                        this.Timer -= 1;
                    }
                    else
                    {
                        this.skin = Resource1.eat_32x32;
                        this.state = "alife"; 
                        this.Timer = 10;
                    }

                }
                else
                {
                    this.Timer = 10;
                    this.state = "alife";
                }
            }
            if(this.state == "fun")
            {
                if(this.eat > 30)
                {
                    this.skin = Resource1.happy_32x32;
                    if (this.happy <= 85)
                    {
                        this.happy += 15;
                        this.eat -= 5;
                        this.state = "alife";
                    }
                    if(this.happy > 85)
                    {
                        this.happy = 100;
                        this.eat -= 5;
                        this.state = "alife";
                    }

                }
                else
                {
                    this.state = "alife";
                }
                
            }
            if (this.state == "grow")
            {
                this.skin = Resource1.pig_walk;
            }
            if (this.state == "fate")
            {
                this.skin = Resource1.isus;
            }
        }
        public void Move()
        {
            // # ← ↑ → ↓ ↔ ↕ ⇆ ⇅ ⬈ ⬉ ⬊ ⬋
        }
        public void Eat()
        {

        }
        public void Fun()
        {

        }
        public void Grow()
        {

        }
    }
    public class Aves : Animal //птицы Pisces
    {
        public void Move()
        {
            // # ← ↑ → ↓ ↔ ↕ ⇆ ⇅ ⬈ ⬉ ⬊ ⬋
        }
        public void Eat()
        {

        }
        public void Fun()
        {

        }
        public void Grow()
        {

        }
    }
    public class Pisces : Animal //рыбы
    {
        public void Move()
        {
            // # ← ↑ → ↓ ↔ ↕ ⇆ ⇅ ⬈ ⬉ ⬊ ⬋
        }
        public void Eat()
        {

        }
        public void Fun()
        {

        }
        public void Grow()
        {

        }
    }

}
