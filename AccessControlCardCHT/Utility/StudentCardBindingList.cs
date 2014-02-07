using System;
using System.ComponentModel;
using AccessControlCardCHT;

namespace AccessControlCardCHT
{
    internal class StudentCardBindingList : SortableBindingList<StudentCard>
    {
        protected override Comparison<StudentCard> GetComparer(PropertyDescriptor prop)
        {
            Comparison<StudentCard> comparer = null;

            switch (prop.Name)
            {
                case "StudentID":
                    comparer = new Comparison<StudentCard>(delegate(StudentCard x, StudentCard y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.StudentID.CompareTo(y.StudentID));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "StudentNumber":
                    comparer = new Comparison<StudentCard>(delegate(StudentCard x, StudentCard y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.StudentNumber.CompareTo(y.StudentNumber));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "ClassName":
                    comparer = new Comparison<StudentCard>(delegate(StudentCard x, StudentCard y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.ClassName.CompareTo(y.ClassName));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "StudentSeatNo":
                    comparer = new Comparison<StudentCard>(delegate(StudentCard x, StudentCard y)
                    {
                        if (x != null)
                            if (y != null)
                                return (K12.Data.Int.Parse(x.StudentSeatNo).CompareTo(K12.Data.Int.Parse(y.StudentSeatNo)));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "StudentName":
                    comparer = new Comparison<StudentCard>(delegate(StudentCard x, StudentCard y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.StudentName.CompareTo(y.StudentName));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "StudentPhone":
                    comparer = new Comparison<StudentCard>(delegate(StudentCard x, StudentCard y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.StudentPhone.CompareTo(y.StudentPhone));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
                case "CardNo":
                    comparer = new Comparison<StudentCard>(delegate(StudentCard x, StudentCard y)
                    {
                        if (x != null)
                            if (y != null)
                                return (x.CardNo.CompareTo(y.CardNo));
                            else
                                return 1;
                        else if (y != null)
                            return -1;
                        else
                            return 0;
                    });
                    break;
            }

            return comparer;
        }
    }
}