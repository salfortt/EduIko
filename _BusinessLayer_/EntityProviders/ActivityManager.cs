using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.EntityProviders
{
   public  class ActivityManager
    {


        /*
        private CompanyDALC _dalc;
        private CompanyDALC dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = CompanyDALC.GetInstance();
                return _dalc;
            }
        }

        private CompanyMap Map
        {
            get
            {
                CachingController cc = CachingController.GetInstance();
                CompanyMap map = cc.GetCompanyMap();

                if (map == null)
                {
                    map = LoadMap();
                    cc.SetCompanyMap(map);
                }
                return map;
            }
        }

        private CompanyMap LoadMap()
        {
            CompanyMap cm = new CompanyMap();
            List<Company> list = dalc.GetCompanies();
            List<Company> CompanyListEn = dalc.GetCompaniesEn();

            cm.SetCompanyList(list);
            cm.SetCompanyEnList(CompanyListEn);
            return cm;
        }

        public void RefreshCompany()
        {
            CachingController cc = CachingController.GetInstance();
            cc.CompanyMapRemoveFromCache();
        }

        public int InsertCompany(Company company)
        {
            int result = dalc.InsertCompany(company);
            if (result > 0)
            {
                company.companyId = result;
                UpdateCompanyItems(company);
            }
            return result;
        }

        public void UpdateCompanyListItems(Company company)
        {
            dalc.DeleteCompanyItems(company.companyId);
            UpdateCompanyItems(company);
        }

        private void UpdateCompanyItems(Company company)
        {
            InsertArastirmaAlan(company.companyId, company.arastirmaAlanlar);
            InsertSahaMetod(company.companyId, company.sahaMetodlar);
            InsertYonetici(company.companyId, company.yoneticiler);
            InsertCertificate(company.companyId, company.certificates);
            InsertMember(company.companyId, company.members);
            InsertTerminalSystem(company.companyId, company.terminalSystems);
            InsertServerSystem(company.companyId, company.serverSystems);
        }

        private void InsertArastirmaAlan(int id, List<ArastirmaAlan> list)
        {
            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                ArastirmaAlan aa = list[i];
                dalc.InsertArastirmaAlan(id, aa.ID);
            }
        }

        private void InsertSahaMetod(int id, List<SahaMetod> list)
        {
            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                SahaMetod aa = list[i];
                dalc.InsertSahaMetod(id, aa.ID);
            }
        }

        private void InsertYonetici(int id, List<Yonetici> list)
        {
            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                Yonetici y = list[i];
                dalc.InsertYonetici(id, y.yoneticiAdSoyad);
            }
        }

        private void InsertCertificate(int id, List<Certificate> list)
        {
            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                Certificate cer = list[i];
                dalc.InsertCertificate(id, cer.certificateId);
            }
        }

        private void InsertMember(int id, List<IMember> list)
        {
            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                IMember cer = list[i];
                dalc.InsertMember(id, cer.memberId);
            }
        }

        private void InsertTerminalSystem(int id, List<TerminalSystem> list)
        {
            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                TerminalSystem aa = list[i];
                dalc.InsertTerminalSystem(id, aa.id);
            }
        }

        private void InsertServerSystem(int id, List<ServerSystem> list)
        {
            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                ServerSystem aa = list[i];
                dalc.InsertServerSystem(id, aa.id);
            }
        }

        public int UpdateCompanyByCompanyId(Company company)
        {
            UpdateCompanyListItems(company);
            return dalc.UpdateCompanyByCompanyId(company);
        }

        public int UpdateCompanyEnByCompanyId(Company company)
        {
            return dalc.UpdateCompanyEnByCompanyId(company);
        }

        public int UpdateCompany(Company company)
        {
            return dalc.UpdateCompany(company);
        }

        public int UpdateCompanyRequest(Company company)
        {
            return dalc.UpdateCompanyRequest(company);
        }

        public int UpdateActiveCompany(int memberid)
        {
            return dalc.UpdateActiveCompany(memberid);
        }

        public int UpdateActiveCompanyByCompanyId(int cid)
        {
            return dalc.UpdateActiveCompanyByCompanyId(cid);
        }

        public int DeleteCompanyByCompanyId(int cid)
        {
            return dalc.DeleteCompanyByCompanyId(cid);
        }

        public Company GetCompany(int companyId)
        {
            Company company = Map.GetCompanyByCompanyId(companyId);
            return company;
        }

        public List<ICompany> GetCompanies()
        {
            List<ICompany> companies = Map.GetCompanies();
            return companies;
        }

        public List<ICompany> GetCompanyListByCityId(int cityId)
        {
            List<ICompany> companies = Map.GetCompanyListByCityId(cityId);
            return companies;
        }

        public List<ICompany> GetCompanyListByTypeId(CompanyTypes type)
        {
            List<ICompany> companies = Map.GetCompanyListByTypeId(type);
            return companies;
        }

        public List<ICompany> GetCompanyListByGab()
        {
            List<ICompany> companies = Map.GetCompanyListByGab();
            return companies;
        }

        public Company GetCompanyByMemberId(int memberId)
        {
            Company c = Map.GetCompanyByMemberId(memberId);
            return c;
        }

        public Company GetCompanyEnByMemberId(int companyid)
        {
            Company c = dalc.GetCompanyEn(companyid);
            return c;
        }

        public List<Company> GetCompaniesEn()
        {
            List<Company> companies = Map.GetCompanyEnList();
            return companies;
        }


    }

    public class CompanyMap
    {
        private Dictionary<int, Company> CompanyById { get; set; }
        private List<Company> CompanyList { get; set; }
        private List<ICompany> CompanyListItem { get; set; }
        private List<Company> companies { get; set; }

        public CompanyMap()
        {
            CompanyById = new Dictionary<int, Company>();
            CompanyList = new List<Company>();
            CompanyListItem = new List<ICompany>();
            companies = new List<Company>();

        }


        internal void SetCompanyEnList(List<Company> CompanyListEn)
        {
            companies = CompanyListEn;

        }
        internal List<Company> GetCompanyEnList()
        {
            return companies;
        }



        public void SetCompanyList(List<Company> companylist)
        {
            CompanyList = companylist;
            for (int i = 0; i < CompanyList.Count; i++)
            {
                Company company = CompanyList[i];
                SetCompanyById(company.companyId, company);
                CompanyListItem.Add(company);
            }
        }

        private void SetCompanyById(int companyId, Company company)
        {
            CompanyById.Add(companyId, company);
        }

        public List<ICompany> GetCompanies()
        {
            return CompanyListItem;
        }

        public List<ICompany> GetCompanyListByCityId(int cityId)
        {
            List<ICompany> companies = null;

            for (int i = 0; i < CompanyList.Count; i++)
            {
                if (companies == null)
                    companies = new List<ICompany>();
                Company company = CompanyList[i];
                if (company.cityId == cityId)
                    companies.Add(company);
            }

            return companies;
        }

        public List<ICompany> GetCompanyListByTypeId(CompanyTypes type)
        {
            List<ICompany> companies = null;

            for (int i = 0; i < CompanyList.Count; i++)
            {
                if (companies == null)
                    companies = new List<ICompany>();
                Company company = CompanyList[i];
                if (company.companyType == type)
                    companies.Add(company);
            }

            return companies;
        }

        public List<ICompany> GetCompanyListByGab()
        {
            List<ICompany> companies = null;

            for (int i = 0; i < CompanyList.Count; i++)
            {
                if (companies == null)
                    companies = new List<ICompany>();
                Company company = CompanyList[i];
                if (company.certificates != null)
                {
                    Certificate cer = company.certificates.Find(each => { return each.certificateId == 7; });
                    if (cer != null)
                        companies.Add(company);
                }
            }

            return companies;
        }

        public Company GetCompanyByCompanyId(int companyid)
        {
            if (CompanyById.ContainsKey(companyid))
                return CompanyById[companyid];
            else
                return null;
        }

        public Company GetCompanyByMemberId(int memberId)
        {
            return CompanyList.Find(each => { return each.memberId == memberId; });
        }



        */



    }
}
