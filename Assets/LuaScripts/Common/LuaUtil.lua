--[[
-- Lua全局工具类，全部定义为全局函数、变量
-- TODO:
-- 1、SafePack和SafeUnpack会被大量使用，到时候看需要需要做记忆表降低GC
--]]

local unpack =  table.unpack

-- 解决原生pack的nil截断问题，SafePack与SafeUnpack要成对使用
function SafePack(...)
    local params = {...}
    params.n = select('#',...)
    return params
end

-- 解决原生pack的nil截断问题，SafePack与SafeUnpack要成对使用
function SafeUnpack(safe_pack_tb)
    return unpack(safe_pack_tb,1,safe_pack_tb.n)
end

--对两个safrPack的表执行连接
function ConcatSafePack(safe_pack_l,safe_pack_r)
    local concat = {}
    --for i = 
end