using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler {
  class SimpleCrawler {
    //private Hashtable urls = new Hashtable();
    /*
     要求一：优先爬取本网页。
     我把hashtable改成了一个queue，在下载解析网页时本网页的链接优先入队，
     就可以实现优先解析
             */
    private Queue<string> urls = new Queue<string>();
    private int count = 0;
    static void Main(string[] args) {
      SimpleCrawler myCrawler = new SimpleCrawler();
      string startUrl = "http://www.cnblogs.com/dstang2000/";
      if (args.Length >= 1) startUrl = args[0];
      myCrawler.urls.Enqueue(startUrl);//加入初始页面
      new Thread(myCrawler.Crawl).Start();
    }

    private void Crawl() {
      Console.WriteLine("开始爬行了.... ");
      while (true) {
        string current = urls.Dequeue();
        /*foreach (string url in urls.Keys) {
          if ((bool)urls[url]) continue;
          current = url;
        }*/
        if (current == null || count > 30) break;
        Console.WriteLine("爬行" + current + "页面!");
        string html = DownLoad(current); // 下载
        //urls[current] = true;
        count++;
        Parse(html,current);//解析,并加入新的链接
        Console.WriteLine("爬行结束");
      }
    }

    public string DownLoad(string url) {
      try {
        WebClient webClient = new WebClient();
        webClient.Encoding = Encoding.UTF8;
        string html = webClient.DownloadString(url);
        string fileName = count.ToString();
        File.WriteAllText(fileName, html, Encoding.UTF8);
        return html;
      }
      catch (Exception ex) {
        Console.WriteLine(ex.Message);
        return "";
      }
    }

    private void Parse(string html,string current) {
       /*
        要求二：只爬取HTML文件
        我在正则表达式中加入了(.html)，这样就只匹配扩展名为HTML的链接
             
             */
      string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(.html)[""']";
      MatchCollection matches = new Regex(strRef).Matches(html);
      foreach (Match match in matches) {
        strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                  .Trim('"', '\"', '#', '>');
      if (strRef.Length == 0) continue;
      /*
            要求三：相对地址向绝对地址转换
            在Parse(string html, string current)中添加了一个参数current，当字符串以“/”开头时
            就是个相对地址，于是在前面拼上current形成绝对地址
                 */
      if (strRef[0] == '/')
              strRef = current+strRef ;
       //if (urls[strRef] == null) urls[strRef] = false;
       urls.Enqueue(strRef);
      }
    }
  }
}
