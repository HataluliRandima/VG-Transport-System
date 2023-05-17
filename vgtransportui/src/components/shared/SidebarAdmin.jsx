import React from 'react'
import classNames from 'classnames'
import { Link, useLocation } from 'react-router-dom'
import { FaPeopleCarry } from 'react-icons/fa'
import { HiOutlineLogout } from 'react-icons/hi'
import { DASHBOARD_D_T  } from '../../lib/constants/naviadmin'


const linkClass =
	'flex items-center gap-2 font-bold px-3 py-2 hover:bg-black hover:no-underline active:bg-black rounded-sm text-base'

const SidebarAdmin = () => {
    function SidebarLink({ link }) {
        const { pathname } = useLocation()
    
        return (
            <Link
                to={link.path}
                className={classNames(pathname === link.path ? 'bg-neutral-700 text-white' : 'text-neutral-400', linkClass)}
            >
                <span className="text-xl">{link.icon}</span>
                {link.label}
            </Link>
        )
    }
  return (
    <div className="bg-white w-60 p-3 flex flex-col rounded-lg border-yellow-500">
    <div className="flex items-center gap-2 px-1 py-3  ">
        <FaPeopleCarry fontSize={24} />
        <span className="text-black text-lg">VG Transport</span>
    </div>
    <div className="py-8 flex flex-1 flex-col gap-0.5">
          {DASHBOARD_D_T.map((link) => (
             <SidebarLink key={link.key} link={link} />
        ))}  
    </div>
    <div className="flex flex-col gap-0.5 pt-2 border-t border-black">
         {/* {DASHBOARDDB.map((link) => (
            <SidebarLink key={link.key} link={link} />
        ))}   */}
         <Link to={'loginc'}>
          <div className={classNames(linkClass, 'cursor-pointer text-red-500 rounded-md  ')}>
         
            <span className="text-xl">
                <HiOutlineLogout />
            </span>
           
            Logout
            
        </div>  
        </Link>
    </div>
</div>
  )
}

export default SidebarAdmin