using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GenPDF
{
    public class PdfGenerator
    {
        public static void GenerateSimpleReport(string filePath)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(style => style.FontSize(14));
                    page.Header().Text("Simple QuestPDF Report");
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Hello, World!");
                        column.Item().Text("QuestPDF makes PDF generation in .NET straightforward.");
                    });
                    //page.Footer().AlignRight().Text(text => text.Span("Page ").PageNumber());
                });
            });

            document.GeneratePdf(filePath);
        }
    }
}
