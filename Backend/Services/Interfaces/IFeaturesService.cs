using ProjectRunAway.Models;

namespace ProjectRunAway.Services.Interfaces
{
    public interface IFeaturesService
    {
        string AddFeature(Features feature);
        void DeleteFeature(Features feature);
        void UpdateFeature(Features feature);
        public Features GetFeatureById(int id);
        public List<Features> EditExisting();
        IEnumerable<Features> GetAllFeatures();

    }
}
