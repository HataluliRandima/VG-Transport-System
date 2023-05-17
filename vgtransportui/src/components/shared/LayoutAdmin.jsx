import React from 'react'
import { Outlet } from 'react-router-dom'
 
import SidebarAdmin from './SidebarAdmin'
import HeaderAdmin from './HeaderAdmin'

   function LayoutAdmin() {
  return (

    <div className="bg-neutral-100 h-screen w-screen overflow-hidden flex flex-row">
            <SidebarAdmin/>
             <div className="flex flex-col flex-1">
             <HeaderAdmin/>
                 <div className="flex-1 p-4 min-h-0 overflow-auto">
                     <Outlet />
                 </div>
             </div>
         </div>
    
  )
}


export default LayoutAdmin