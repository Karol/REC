using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKarol.Models
{
    public class MyConvert
    {
        public TbType ConvertTyp(TypViewModel tbtype)
        {
            return new TbType() 
            {
                TbTypeID = tbtype.TypID,
                Name = tbtype.TypName
            };
        }

        public TbIssue ConvertIssue(IssueViewModel tbissue)
        {
            return new TbIssue()
            {
                TbIssueID = tbissue.IssueId,
                Name = tbissue.IssueName,
                Text = tbissue.IssueText,
                TbType = tbissue.TbtypeN             
            };
        }

        public TypViewModel ConvertTypToView(TbType tbtype)
        {
            return new TypViewModel()
            {
                TypID = tbtype.TbTypeID,
                TypName = tbtype.Name
            };
        }

        public IssueViewModel ConvertIssueToView(TbIssue tbissue)
        {
            return new IssueViewModel()
            {
                 IssueId = tbissue.TbIssueID,
                 IssueName = tbissue.Name,
                 IssueText = tbissue.Text,
                 TbtypeN = tbissue.TbType
            };
        }
    }
}