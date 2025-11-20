//Layouts
import { HeaderOnly, SidebarOnly } from '../components/Layout';

// Pages
import Home from '../pages/Home';
import AboutMe from '../pages/AboutMe';
import Login from '../pages/Login';
import SignUp from '../pages/SignUp';
import Services from '../pages/Services';
import Product from '../pages/Product';
import Register from '../pages/Register';
import Account from '../pages/Account';
import PaymentPage from '../pages/Payment/Payment';

// admin pages
import ListUser from '../pages/ListUser';
import ListRegister from '../pages/ListRegister';
import ListInsurance from '../pages/ListInsurance';
import ListBenefits from '../pages/ListBenefit';
import DashBoard from '../pages/Dashboard';
import ListRequest from '../pages/ListRequest';
import AddInsurance from '../pages/AddInsurance';
import UpdateInsurance from '../pages/UpdateInsurance';
import DetailInsurance from '../pages/DetailInsurance';
import DetailContract from '../pages/DetailContract';
import ListPayment from '../pages/ListPayment';
import DetailPayment from '../pages/ListPayment/DetailPayment';
import ListPaymentPaid from '../pages/ListPaymentPaid';
//
const publicRoutes = [
    { path: '/', component: Home },
    { path: '/aboutme', component: AboutMe },
    { path: '/login', component: Login, layout: HeaderOnly },
    { path: '/signup', component: SignUp, layout: HeaderOnly },
    { path: '/service', component: Services },
    { path: '/service/:id', component: Product },
    { path: '/register/:id', component: Register },
    { path: '/account', component: Account },
    // { path: '/payment', component: PaymentPage },

    //private
    { path: '/admin', component: DashBoard, layout: SidebarOnly },
    { path: '/admin/registers', component: ListRegister, layout: SidebarOnly },
    { path: '/admin/detail-contract/:id', component: DetailContract, layout: SidebarOnly },
    { path: '/admin/users', component: ListUser, layout: SidebarOnly },
    { path: '/admin/insurances', component: ListInsurance, layout: SidebarOnly },
    { path: '/admin/benefits', component: ListBenefits, layout: SidebarOnly },
    { path: '/admin/add-insurances', component: AddInsurance, layout: SidebarOnly },
    { path: '/admin/update-insurances/:id', component: UpdateInsurance, layout: SidebarOnly },
    { path: '/admin/detail-insurance/:id', component: DetailInsurance, layout: SidebarOnly },
    { path: '/admin/request', component: ListRequest, layout: SidebarOnly },
    { path: '/admin/payment', component: ListPayment, layout: SidebarOnly },
    { path: '/admin/paymentpaid', component: ListPaymentPaid, layout: SidebarOnly },
    { path: '/admin/payment/detail', component: DetailPayment },
];

export { publicRoutes };
