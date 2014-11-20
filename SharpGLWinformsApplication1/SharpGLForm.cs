using System;
using System.Windows.Forms;
using SharpGL;
using SharpGLWinformsApp;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Effects;

namespace SharpGLWinformsApp
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        private static OpenGL gl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            getInstance();           
        }

        public OpenGL getInstance()
        {
            if (gl == null) 
            InitializeComponent();
            return gl;

        }
       
        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        public void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object.
            gl = openGLControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Load the identity matrix.
            gl.LoadIdentity();

            //  Rotate around the Y axis.
            //gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);
            this.ModelRotater(gl);

            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            //  Draw a coloured parallelepiped.            
            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-2.0f, -0.25f, -1.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(2.0f, -0.25f, -1.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(2.0f, 0.25f, -1.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-2.0f, 0.25f, -1.0f);
            //-------------------------------------
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(-2.0f, -0.25f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(-2.0f, -0.25f, 1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(-2.0f, 0.25f, 1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(-2.0f, 0.25f, -1.0f);
            //-------------------------------------
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-2.0f, -0.25f, 1.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(2.0f, -0.25f, 1.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(2.0f, 0.25f, 1.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-2.0f, 0.25f, 1.0f);
            //-------------------------------------
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(2.0f, -0.25f, 1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(2.0f, -0.25f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(2.0f, 0.25f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(2.0f, 0.25f, 1.0f);
            //-------------------------------------
            gl.Color(0.0f, 1.0f, 1.0f);
            gl.Vertex(-2.0f, 0.25f, -1.0f);

            gl.Color(0.0f, 1.0f, 1.0f);
            gl.Vertex(2.0f, 0.25f, -1.0f);

            gl.Color(0.0f, 1.0f, 1.0f);
            gl.Vertex(2.0f, 0.25f, 1.0f);

            gl.Color(0.0f, 1.0f, 1.0f);
            gl.Vertex(-2.0f, 0.25f, 1.0f);
            //--------------------------------------
            gl.Color(0.0f, 0.0f, 1.0f); 
            gl.Vertex(-2.0f, -0.25f, -1.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(2.0f, -0.25f, -1.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(2.0f, -0.25f, 1.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-2.0f, -0.25f, 1.0f);

            gl.End();

            //-------------------Angle indicator prototype is here----------------------------------------------
            gl.LoadIdentity();

            gl.Rotate(ComInput.Coordinates.osX, 1.0f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Vertex(0.0f, 2.75f, 0.0f);
            gl.Vertex(0.25f, 3.25f, 0.0f);
            gl.Vertex(-0.25f, 3.25f, 0.0f);

            gl.End();

            gl.LoadIdentity();

            gl.Rotate(ComInput.Coordinates.osY, 0.0f, 1.0f, 0.0f);

            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Vertex(0.0f, 0.0f, 2.75f);
            gl.Vertex(0.0f, 0.25f, 3.25f);
            gl.Vertex(0.0f, -0.25f, 3.25f);

            gl.End();

            gl.LoadIdentity();

            gl.Rotate(ComInput.Coordinates.osZ, 0.0f, 0.0f, 1.0f);

            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Vertex(2.75f, 0.0f, 0.0f);
            gl.Vertex(3.25f, 0.0f, 0.25f);
            gl.Vertex(3.25f, 0.0f, -0.25f);

            gl.End();

            //------------------Circles of planes is here-----------------------------------------------
            
            gl.LoadIdentity();

            gl.Begin(OpenGL.GL_LINE_LOOP);
            for(int i = 0; i < 200; i++)
            {
                float theta = 2.0f * 3.1415926f * (float)i / 200f;//get the current angle

                float x = 3f * (float)System.Math.Cos(theta);//calculate the x component
                float y = 3f * (float)System.Math.Sin(theta);//calculate the y component

                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(0f, y + 0.0f, x + 0.0f);//output vertex

            }
            gl.End();

            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < 200; i++)
            {
                float theta = 2.0f * 3.1415926f * (float)i / 200f;//get the current angle

                float x = 3f * (float)System.Math.Cos(theta);//calculate the x component
                float y = 3f * (float)System.Math.Sin(theta);//calculate the y component

                gl.Vertex(x + 0.0f, 0.0f, y + 0.0f);//output vertex

            }
            gl.End();

            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < 200; i++)
            {
                float theta = 2.0f * 3.1415926f * (float)i / 200f;//get the current angle

                float x = 3f * (float)System.Math.Cos(theta);//calculate the x component
                float y = 3f * (float)System.Math.Sin(theta);//calculate the y component

                gl.Vertex(x + 0.0f, y + 0.0f, 0.0f);//output vertex

            }
            gl.End(); 

            /* //--------------Coordinate axis's is here--------------------------------------------

            gl.LoadIdentity();

            gl.Begin(OpenGL.GL_LINE_STRIP);

            gl.Color(1.0f, 1.0f, 1.0f);
            
            gl.Vertex(-4.0f, 0.5f, 1.5f);
            gl.Vertex(2.5f, 0.5f, 1.5f);
            gl.Vertex(2.5f, 0.5f, -4.5f);
            gl.Vertex(2.5f, 0.5f, 1.5f);
            gl.Vertex(2.5f, 4.0f, 1.5f);

            gl.End();

            */ //------------Shpere is here-----------------------------

            gl.LoadIdentity();

            gl.Color(0.85f, 0.85f, 0.85f, 0.5f);

            gl.Begin(OpenGL.GL_QUADS);
            for (int i = 0; i < 1; i++)
            {
                this.draw_sphere(gl, 3);
            }
            gl.End();
 
            //---------------3D Text prototype is here-------------------

            gl.LoadIdentity();

            gl.Translate(0.0f, 3.5f, -3.0f);

            gl.Color(0.0f, 1.0f, 0.65f);

            gl.Rotate(270.0f, 0.0f, 1.0f, 0.0f);

            gl.DrawText3D("a", 0.2f,
                1.0f, 0.1f, "osX: 0");


            //  Nudge the rotation.
            rotation += 2.0f;
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  TODO: Initialise OpenGL here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();                

            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 2, 0);           

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        /// <summary>
        /// The current rotation.
        /// </summary>
        private float rotation = 0.0f;
      //  private float angleX = 0.0f, angleY = 0.0f, angleZ = 0.0f, x = 1;
      //  private int counter = 0;

        private void ModelRotater(OpenGL testObject)
        {
            testObject.Rotate(ComInput.Coordinates.osX, 1.0f, 0.0f, 0.0f); //ComInput.osX
            testObject.Rotate(ComInput.Coordinates.osY, 0.0f, 1.0f, 0.0f);
            testObject.Rotate(ComInput.Coordinates.osZ, 0.0f, 0.0f, 1.0f);


            int h, w;
            h = openGLControl.Size.Height / 4;
            w = (openGLControl.Size.Width * 4) / 5;
            string text = "x: " + ComInput.Coordinates.osX.ToString(); // +", " + ComInput.osY.ToString() + ", " + ComInput.osZ.ToString();
            testObject.DrawText(w, h, 1, 1, 1, "faceName", 20, text);

            h = openGLControl.Size.Height / 5;
            text = "y: " + ComInput.Coordinates.osY.ToString();
            testObject.DrawText(w, h, 1, 1, 1, "faceName", 20, text);

            h = (openGLControl.Size.Height * 3) / 20;
            text = "z: " + ComInput.Coordinates.osZ.ToString();
            testObject.DrawText(w, h, 1, 1, 1, "faceName", 20, text);
        }

        public void draw_sphere(OpenGL gl, double agent)
        {
            Sphere sphere = new SharpGL.SceneGraph.Quadrics.Sphere();
            sphere.Radius = agent;            
            GLColor glClr = new GLColor(0.0f, 0.0f, 1.0f, 0.5f);            
            OpenGLAttributesEffect glEffect = new OpenGLAttributesEffect();
            glEffect.ColorBufferAttributes.ColorModeClearColor = glClr;
            glEffect.ColorBufferAttributes.ColorModeWriteMask = glClr;            

            sphere.NormalGeneration = SharpGL.SceneGraph.Quadrics.Normals.Smooth;
            sphere.NormalOrientation = SharpGL.SceneGraph.Quadrics.Orientation.Outside;
            sphere.QuadricDrawStyle = SharpGL.SceneGraph.Quadrics.DrawStyle.Fill;
            sphere.AddEffect(glEffect);

            sphere.CreateInContext(gl);

            sphere.Slices = 100;
            sphere.Stacks = 100;
            sphere.TextureCoords = false;

            sphere.PushObjectSpace(gl);
            sphere.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            sphere.PopObjectSpace(gl);

            
        }

    }
}
