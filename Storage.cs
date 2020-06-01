using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class Storage
    {
        List<Sample> samples;

        public Storage(){
            samples=new List<Sample>();
        }

        public void SaveSample(Sample S){
            if(S==null)return;
            if(samples.Contains(S))samples.Remove(S);
            samples.Add(S);
        }

        public List<Sample> GetFiltredSamples(TypesEnums.Type T){
            List<Sample> filtredSamples=new List<Sample>();
            foreach(Sample S in samples.Where(s => (s.getType == (int)T))){
                    if(S.haveData()){ 
                    filtredSamples.Add(S);
                }
            }
            return filtredSamples;
        }
        public List<Sample> GetAllSamples(){
            List<Sample> filtredSamples=new List<Sample>();
            foreach(Sample S in samples.Where(s => s.haveData()==true)){
                    filtredSamples.Add(S);
            }
            return filtredSamples;
        }

        public void ClearStorage(){
            samples.Clear();    
        }

        public bool isStorageEmpty(){ 
            if(samples.Count==0)return true;
            else return false;
        }

        public int getNumberOfBadSamples(){
            int error=0;
            foreach(Sample S in samples.Where(s=> s.haveData() == false)){ 
                error++;
            }
            return error;
        }
        public List<Sample> getBadSamples(){
            List<Sample> badSamples=new List<Sample>();
            foreach(Sample S in samples.Where(s=> s.haveData() == false)){
                badSamples.Add(S);
            }
            return badSamples;
        }

        public int getNumberOfSamples(){
            return samples.Count;
        }
    }
}
