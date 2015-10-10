using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellClaimDomain.DataModel;
using Ploeh.AutoFixture;
using MitchellClaimDomain.Classes.Entities;

namespace MitchellClaimDomain.DataModelTest
{
    [TestClass]
    public class MitchellClaimRepositoryTests
    {
        [TestMethod]
        public void AddMitchellClaimShouldReturnAddedClaimId()
        {            
            var repo = new MitchellClaimRepository(new MitchellClaimContext());
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior()); 
            var claim = fixture.Create<MitchellClaimType>();
            int id = repo.AddMitchellClaim(claim);
            
            Assert.AreNotEqual(0, id);

        }

        [TestMethod]
        public void GetMitchellClaimByClaimIdShouldReturnClaimId()
        {           
            var repo = new MitchellClaimRepository(new MitchellClaimContext());
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var claim = fixture.Create<MitchellClaimType>();
            int id = repo.AddMitchellClaim(claim);

            MitchellClaimType m = repo.GetMitchellClaimByClaimId(id);

            Assert.AreEqual(id, m.Id);
        }

         [TestMethod]
        public void GetMitchellClaimByClaimNumberShouldReturnClaimNumber()
        {           
            var repo = new MitchellClaimRepository(new MitchellClaimContext());
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var claim = fixture.Create<MitchellClaimType>();
            int id = repo.AddMitchellClaim(claim);
           
            MitchellClaimType m = repo.GetMitchellClaimByClaimId(id);

            MitchellClaimType m1 = repo.GetMitchellClaimByClaimNumber(m.ClaimNumber);

            Assert.AreEqual(m.ClaimNumber, m1.ClaimNumber);
        }

         [TestMethod]
         public void UpdateMitchellClaimShouldReturnDiffFirtName()
         {
             var repo = new MitchellClaimRepository(new MitchellClaimContext());
             var fixture = new Fixture();
             fixture.Behaviors.Add(new OmitOnRecursionBehavior());
             var claim = fixture.Create<MitchellClaimType>();
             int id = repo.AddMitchellClaim(claim);

             MitchellClaimType m = repo.GetMitchellClaimByClaimId(id);
            
             m.ClaimantFirstName = "Thierry";
             repo.UpdateMitchellClaim(m);

             MitchellClaimType m1 = repo.GetMitchellClaimByClaimId(id);

             Assert.AreEqual(m1.ClaimantFirstName, "Thierry");
         }

         [TestMethod]
         public void DeleteMitchellClaimShouldReturnTrue()
         {
             var repo = new MitchellClaimRepository(new MitchellClaimContext());
             var fixture = new Fixture();
             fixture.Behaviors.Add(new OmitOnRecursionBehavior());
             var claim = fixture.Create<MitchellClaimType>();
             int id = repo.AddMitchellClaim(claim);

             MitchellClaimType m = repo.GetMitchellClaimByClaimId(id);            
            bool res = repo.DeleteMitchellClaim(m.ClaimNumber);

             Assert.AreEqual(true, res);
         }
        
    }
}
