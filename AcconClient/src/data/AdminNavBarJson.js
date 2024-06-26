import {MdDashboard, MdHomeRepairService, MdSettings} from "react-icons/md";
import {BsMenuButtonWide} from "react-icons/bs";
import {GrGallery} from "react-icons/gr";
import {FaComment, FaLanguage, FaNewspaper, FaQuestionCircle} from "react-icons/fa";
import {FaBoltLightning, FaPhotoFilm} from "react-icons/fa6";
import {IoMenu, IoPersonAdd, IoShareSocialSharp} from "react-icons/io5";
import {RiPagesLine, RiTeamFill} from "react-icons/ri";
import {SiNginxproxymanager} from "react-icons/si";

export const menuItems = [
    {
        path: '',
        icon: <MdDashboard />,
        label: 'Dashboard'
    },
    {
        path: 'settings',
        icon: <MdSettings />,
        label: 'Settings'
    },
    {
        path: 'menu',
        icon: <BsMenuButtonWide />,
        label: 'Menu'
    },
    {
        path: 'slider',
        icon: <GrGallery />,
        label: 'Slider'
    },
    {
        path: 'service',
        icon: <MdHomeRepairService />,
        label: 'Service'
    },
    {
        section: 'faq',
        icon: <FaQuestionCircle />,
        label: 'FAQ',
        subItems: [
            {
                path: 'faq',
                label: 'FAQ'
            },
            {
                path: 'main-photo',
                label: 'Main Photo'
            }
        ]
    },
    {
        section: 'photoGallery',
        icon: <FaPhotoFilm />,
        label: 'Photo Gallery',
        subItems: [
            {
                path: 'photo-gallery',
                label: 'Photo'
            }
        ]
    },
    {
        section: 'portfolio',
        icon: <IoMenu />,
        label: 'Portfolio',
        subItems: [
            {
                path: 'portfolio-category',
                label: 'Portfolio Category'
            },
            {
                path: 'portfolio',
                label: 'Portfolio'
            }
        ]
    },
    {
        section: 'teamMember',
        icon: <RiTeamFill />,
        label: 'Team Member',
        subItems: [
            {
                path: 'designation',
                label: 'Designation'
            },
            {
                path: 'team-member',
                label: 'Team Member'
            }
        ]
    },
    {
        section: 'testimonial',
        icon: <IoPersonAdd />,
        label: 'Testimonial',
        subItems: [
            {
                path: 'testimonial',
                label: 'Testimonial'
            },
            {
                path: 'main-photo',
                label: 'Main Photo'
            }
        ]
    },
    {
        path: 'partner',
        icon: <SiNginxproxymanager />,
        label: 'Partner'
    },
    {
        section: 'whyChooseUs',
        icon: <FaBoltLightning />,
        label: 'Why Choose Us',
        subItems: [
            {
                path: 'why-choose-us',
                label: 'Why Choose'
            },
            {
                path: 'main-photo',
                label: 'Main Photo'
            },
            {
                path: 'items-background',
                label: 'Items Background'
            }
        ]
    },
    {
        path: 'page',
        icon: <RiPagesLine />,
        label: 'Page'
    },
    {
        section: 'newsSection',
        icon: <FaNewspaper />,
        label: 'News Section',
        subItems: [
            {
                path: 'news-category',
                label: 'News Category'
            },
            {
                path: 'news',
                label: 'News'
            }
        ]
    },
    {
        path: 'comment',
        icon: <FaComment />,
        label: 'Comment'
    },
    {
        path: 'language',
        icon: <FaLanguage />,
        label: 'Language'
    },
    {
        path: 'social-media',
        icon: <IoShareSocialSharp />,
        label: 'Social Media'
    }
];
