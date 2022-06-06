using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
    internal class News
    {
        private string title;   // название
        private string date;    // дата создания
        private string text;    // содержимое
        private News next;

        public News (string title, string date, string text) // конструктор
        {
            this.title = title;
            this.date = date;
            this.text = text;
            this.next = null;
        }

        public string getTitle() // получение названия
        {
            return title;
        }

        public string getDate() // получение даты
        {
            return date;
        }

        public string getText() // получение содержимого
        {
            return text;
        }

        public News getNext() // получение следующего элемента
        {
            return next;
        }

        public void setTitle(string text) // установка названия
        {
            this.text = text;
        }

        public void setDate(string date) // установка даты
        {
            this.date = date;
        }

        public void setText(string text) // установка содержимого
        {
            this.text = text;
        }

        public void setNext(News next) // установка следующего элемента
        {
            this.next = next;
        }
    }

    internal class Section
    {
        private string name;        // название раздела
        private News HeadNew = null;// начало новости раздела
        private int news_len = 0;   // количество новостей

        public Section(string name) // конструктор
        {
            this.name = name;
        }

        public string getName() //получение имени
        {
            return this.name;
        }

        public News GetHeadNew() //получение начала раздела
        {
            return this.HeadNew;
        }

        public int getLen() //получение количества новостей
        {
            return news_len;
        }

        public void setName(string name) // установка имени раздела 
        {
            this.name = name;
        }

        public string getNewsTitles() // получение названия всех новостей в разделе
        {
            if (news_len == 0)
                return null;
            News tmp = HeadNew;
            string info = "";
            while (tmp != null)
            {
                if (tmp.getTitle() != null)
                {
                    info += tmp.getTitle() + " (" +tmp.getDate() + ")" + ";";
                }
                tmp = tmp.getNext();
            }
            return info;
        }

        public string getTitle(int i) //получение названия конкретной новости
        {
            if (HeadNew == null)
                return null;
            else
            {
                News tmp = HeadNew;
                int j = -1;
                while (++j < i && (tmp.getNext() != null))
                    tmp = tmp.getNext();
                return tmp.getTitle();
            }
        }

        public string getDate(int i) //получение даты конкретной новости 
        {
            if (HeadNew == null)
                return null;
            else
            {
                News tmp = HeadNew;
                int j = -1;
                while (++j < i && (tmp.getNext() != null))
                    tmp = tmp.getNext();
                return tmp.getDate();
            }
        }

        public string getText(int i) //получение текста конкретной новости
        {
            if (HeadNew == null)
                return null;
            else
            {
                News tmp = HeadNew;
                int j = -1;
                while (++j < i && (tmp.getNext() != null))
                    tmp = tmp.getNext();
                return tmp.getText();
            }
        }

        public string getLastTitle()  //получение названия последней новости
        {
            if (HeadNew == null)
                return null;
            News tmp = HeadNew;
            while (tmp.getNext() != null)
                tmp = tmp.getNext();
            return tmp.getTitle();
        }

        public string getNewsDate() //получение всех дат новостей
        {
            if (news_len == 0)
                return null;
            News tmp = HeadNew;
            string info = "";
            while (tmp != null)
            {
                if (tmp.getDate() != null)
                {
                    info += tmp.getDate() + ";";
                }
                tmp = tmp.getNext();
            }
            return info;
        }
        
        public string getNewsText() //получение текста всех новостей
        {
            if (news_len == 0)
                return null;
            News tmp = HeadNew;
            string info = "";
            while (tmp != null)
            {
                if (tmp.getText() != null)
                {
                    info += tmp.getText() + ";";
                }
                tmp = tmp.getNext();
            }
            return info;
        }

        public News getNews(string find) //получение текста всех новостей
        {
            News tmp = HeadNew;
            while (tmp != null)
            {
                if (tmp.getTitle() == find)
                    return tmp;
                tmp = tmp.getNext();
            }
            return null;
        }

        public void setNews(string name, string date, string text) // добавление новости
        {
            News tmp = new News(name, date, text);
            
            if (HeadNew == null)
                HeadNew = tmp;
            else
            {
                News last = HeadNew;
                while (last.getNext() != null)
                    last = last.getNext();
                last.setNext(tmp);
            }
            this.news_len++;
        }

        public void setTitle(string title, int i) // установка нового названия конкретной новост
        {
            if (HeadNew == null)
                return;
            else
            {
                News tmp = HeadNew;
                int j = -1;
                while (++j < i && (tmp.getNext() != null))
                    tmp = tmp.getNext();
                tmp.setTitle(title);
            }
        }

        public void setDate(string date, int i) // установка новой даты конкретной новости
        {
            if (HeadNew == null)
                return;
            else
            {
                News tmp = HeadNew;
                int j = -1;
                while (++j < i && (tmp.getNext() != null))
                    tmp = tmp.getNext();
                tmp.setDate(date);
            }
        }

        public void setText(string text, int i) // установка нового текста конкретной новости
        {
            if (HeadNew == null)
                return;
            else
            {
                News tmp = HeadNew;
                int j = -1;
                while (++j < i && (tmp.getNext() != null))
                    tmp = tmp.getNext();
                tmp.setText(text);
            }
        }

        public void deleteNews() // удалить новость
        {
            if (HeadNew == null || this.news_len == 0)
                return;
            if (HeadNew.getNext() == null)
            {
                HeadNew = null;
            }
            else
            {
                News last = HeadNew;
                News prev = HeadNew;
                while (last.getNext() != null)
                    last = last.getNext();
                while (prev.getNext() != last)
                    prev = prev.getNext();
                prev.setNext(null);
                last = null;
            }
            this.news_len--;
        }

    }


    internal class Portal
    {
        private int len;    // длина разделов
        private Section[] SectionQueue = new Section[6];    // список на основе очереди разделов
        private int first, last;    // указатель на 1ый и последний элемент
        private int current = -1;   // указатель на выбранный раздел

        public Portal()   // конструктор
        {
            this.first = 0;
            this.last = -1;
            this.len = 0;
        }

        public int getLen()   // получение к-ва разделов
        {
            return len;
        }

        public int getFirst()   // получение индекса первого элемента
        {
            return first;
        }

        public int getLast()   // получение индекса последнего элемента
        {
            return last;
        }

        public int getCurrent()   // получение индекса выбранного элемента
        {
            return current;
        }

        public string getSectionName(int i)   // получение название раздела
        {
            return SectionQueue[i].getName();
        }

        public void addSection(string name)   // добавление нововго раздела
        {
            if (this.len > 4)
                return;
            Section tmp = new Section(name);
            if (last == -1)
                last = 0;
            else if (last == 4)
               return ;
            else
                this.last++;
            SectionQueue[this.last] = tmp;
            this.len++;
        }

        public void deleteSection() // удаление раздела
        {
            if (len == 0)
                return;
            if (last == -1)
                return;
            SectionQueue[this.last] = null;
            last--;
            len--;
        }

        public string openSection(int i)    // открытие раздела
        {
            current = i;
            return SectionQueue[i].getNewsTitles();
        }

        public void addNews(string name, string date, string text)    // добавление новости
        {
            SectionQueue[current].setNews(name, date, text);
        }

        public int getNewsLen()    // получение кол-ва новостей
        {
            return SectionQueue[current].getLen();
        }

        public string getTitle(int i)    // получение названия конкретной новости
        {
            if (i == -1 || i > SectionQueue[current].getLen())
                return null;
            return SectionQueue[current].getTitle(i);
        }

        public string getDate(int i)    // получение даты конкретной новости
        {
            if (i == -1 || i > SectionQueue[current].getLen())
                return null;
            return SectionQueue[current].getDate(i);
        }

        public string getText(int i)    // получение текста конкретной новости
        {
            if (i == -1 || i > SectionQueue[current].getLen())
                return null;
            return SectionQueue[current].getText(i);
        }

        public string getLastTitle()    // получение названия последней новости
        {
            if (SectionQueue[current].getLen() == 0)
                return null;
            return SectionQueue[current].getLastTitle();
        }

        public int getCurrentLen()    // получение длины разделов
        {
            if (current == -1)
                return 0;
            return SectionQueue[current].getLen();
        }

        public int getFullLen()    // получение к-ва новостей всего портала
        {
            int x = 0;
            int i = -1;
            while (++i < len)
                x += SectionQueue[i].getLen();
            return x;
        }

        public void setTitle(string title, int i)    // установка нового названия конкретной новости
        {
            if (i == -1 || i > SectionQueue[current].getLen())
                return;
            SectionQueue[current].setTitle(title, i);
        }

        public void setDate(string date, int i)    // установка новой даты конкретной новости
        {
            if (i == -1 || i > SectionQueue[current].getLen())
                return;
            SectionQueue[current].setDate(date, i);
        }

        public void setText(string text, int i)    // установка нового текста конкретной новости
        {
            if (i == -1 || i > SectionQueue[current].getLen())
                return;
            SectionQueue[current].setText(text, i);
        }

        public void deleteNews()    // удалить новость
        {
            if (current == -1)
                return;
            if (SectionQueue[current].getLen() == 0)
                return;
            SectionQueue[current].deleteNews();
        }
    }
}
