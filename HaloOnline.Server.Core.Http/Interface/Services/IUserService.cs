using HaloOnline.Server.Core.Http.Model.User;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IUserService
    {
        SignOutResult SignOut(SignOutRequest request);
        GetUsersByNicknameResult GetUsersByNickname(GetUsersByNicknameRequest request);
        NicknameChangeResult NicknameChange(NicknameChangeRequest request);
        GetUsersBaseDataResult GetUsersBaseData(GetUsersBaseDataRequest request);
        GetUsersPrimaryStatesResult GetUsersPrimaryStates(GetUsersPrimaryStatesRequest request);
        GetUserStatesResult GetUserStates(GetUserStatesRequest request);
        GetTransactionHistoryResult GetTransactionHistory(GetTransactionHistoryRequest request);
        ApplyExternalOfferResult ApplyExternalOffer(ApplyExternalOfferRequest request);

        ApplyOfferAndGetTransactionHistoryResult ApplyOfferAndGetTransactionHistory(
            ApplyOfferAndGetTransactionHistoryRequest request);

        ApplyOfferListAndGetTransactionHistoryResult ApplyOfferListAndGetTransactionHistory(
            ApplyOfferListAndGetTransactionHistoryRequest request);

        ApplyOfferResult ApplyOffer(ApplyOfferRequest request);
        ApplyOfferListResult ApplyOfferList(ApplyOfferListRequest request);
        GetItemOffersResult GetItemOffers(GetItemOffersRequest request);
        GetShopResult GetShop(GetShopRequest request);
    }
}
