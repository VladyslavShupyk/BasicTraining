using NET01._1.Lessons;
using NET01._1.Materials;
using System;

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
