using NET01._1.Lessons;
using NET01._1.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1.Extensions
{
    static class Extensions
    {
        public static void SetNewGuidLesson(this TrainingLesson lesson)
        {
            lesson.guid = Guid.NewGuid();
        }
        public static void SetNewGuidMaterial(this TrainingMaterial material)
        {
            material.guid = Guid.NewGuid();
        }
    }
}
