using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class Camera {
        public static Matrix viewMatrix;
        private static Vector2 m_position;
        private static Vector2 m_halfViewSize = new Vector2(25 * 16, 15 * 16);

        public static Vector2 Pos
        {
            get
            {
                return m_position;
            }

            set
            {
                m_position = value;
                UpdateViewMatrix();
            }
        }

        private static void UpdateViewMatrix() {
            viewMatrix = Matrix.CreateTranslation(m_halfViewSize.X - m_position.X, m_halfViewSize.Y - m_position.Y, 0.0f);
        }
    }
}
