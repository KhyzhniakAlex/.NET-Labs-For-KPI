using System.ServiceModel;

namespace WcfMsmqService.Interfaces
{
    [ServiceContract]
    public interface IAcademicService
    {
        #region drivers
        [OperationContract(IsOneWay = true)]
        void CreateCar(string Car);

        [OperationContract(IsOneWay = true)]
        void UpdateCar(string updatedCar);

        [OperationContract(IsOneWay = true)]
        void RemoveCar(string CarId);
        #endregion

        #region shifts
        [OperationContract(IsOneWay = true)]
        void CreateOrder(string Order);

        [OperationContract(IsOneWay = true)]
        void UpdateOrder(string updatedOrder);

        [OperationContract(IsOneWay = true)]
        void RemoveOrder(string OrderId);
        #endregion

        #region routes
        [OperationContract(IsOneWay = true)]
        void CreateCiO(string CiO);

        [OperationContract(IsOneWay = true)]
        void UpdateCiO(string updatedCiO);

        [OperationContract(IsOneWay = true)]
        void RemoveCiO(string CiOId);
        #endregion
    }
}
