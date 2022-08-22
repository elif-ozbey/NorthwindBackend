using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCutingConcern.Cashing
{
    public interface ICacheManager
    {//Cash te Neler yapilacaksa onlari yazacagiz
        T Get<T>(string key); //belli bir tipteki cash degerini okumaya calisacagim
        object Get(string key);//obje olarak kullanmak icin. 
        void Add(string key, object data, int duration);//Get okumak icindi, add cah e eklemek icin.
                                                        //key degeri ile ekleriz,datasi neyse onu ekleriz, ne kadar duracaksa onu da ekleriz
        bool IsAdd(string key); //cash den mi getireyim
        void Remove(string key);//belli bir keydeki cash in ortadan kaldirilmasini saglar
        void RemoveByPattern(string pattern);//patterna uyanlarin silinmesini saglar. orn>get ile baslayan butun cashlerin silinmesi saglanabilir
    }
}
