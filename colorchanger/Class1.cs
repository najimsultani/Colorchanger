using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace colorchanger
{
    internal class Blogpost
    {
        string _header; //head
        string _body; //body
        DateTime _posted; //time
        Brush _headerForeground;
        Brush _bodyForeground;  

        public Blogpost(string header, string body, Brush headerColor, Brush bodColor)
        {
            _header = header;
            _body = body;
            _headerForeground= headerColor;
            _bodyForeground= bodColor;
            _posted= DateTime.Now;
        }

        public string Header { get =>_header; set => _header = value;}

        public string body { get => _body; set => _body = value;}

        public DateTime Posted { get => _posted; }

        public override string ToString()
        {
            return $"{_posted.ToShortDateString()} - {_header}";
        }
        public string post()
        {
            string date = _posted.ToShortDateString();
            string header = $"{date} - {_header}";
            string space = $"\n\n";
            string body = _body;    

            string full = header + space + body ;   
            return full ;
        }
        public Paragraph PostFormatted()
        {
            string date = _posted.ToShortDateString() ;
            string header = $"{date} - {_header}";
            string space = $"\n\n";
            string body = _body;
            string full = header + space + body;

            Run ruHeader = new Run(header + space);


            Run runBody= new Run(body);
            runBody.Foreground= _bodyForeground;    

            Paragraph paragraphFull = new Paragraph();
            paragraphFull.Inlines.Add(runBody);

            return paragraphFull;
        }

        private Run HeaderFormatted(string headerText)
        {
            Run header = new Run(headerText);
            header.FontSize = 22;
            header.FontWeight = FontWeights.Bold;
            header.Foreground = _headerForeground;  

            return header;
        }

        private Run BodyFormatted(string bodyText)
        {
            Run body = new Run(bodyText);
            body.Foreground= _bodyForeground;

            return body;
        }


        public Paragraph FullPost()
        {
            string header = _header;
            string spacing = "\n\n";
            string body = _body;    

            Paragraph fullPost= new Paragraph();

            fullPost.Inlines.Add(HeaderFormatted(_header));
            fullPost.Inlines.Add(new Run(spacing));
            fullPost.Inlines.Add(BodyFormatted(_body));

            return fullPost;
        }
    }
}
