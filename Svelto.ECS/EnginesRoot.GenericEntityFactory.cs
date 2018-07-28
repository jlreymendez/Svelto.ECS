﻿#if ENGINE_PROFILER_ENABLED && UNITY_EDITOR
using Svelto.ECS.Profiler;
#endif

namespace Svelto.ECS
{
    public partial class EnginesRoot
    {
        class GenericEntityFactory : IEntityFactory
        {
            readonly DataStructures.WeakReference<EnginesRoot> _weakEngine;

            public GenericEntityFactory(DataStructures.WeakReference<EnginesRoot> weakReference)
            {
                _weakEngine = weakReference;
            }

            public EntityStructInitializer BuildEntity<T>(int entityID, object[] implementors) where T : IEntityDescriptor, new()
            {
                return _weakEngine.Target.BuildEntity<T>(new EGID(entityID), implementors);
            }

            public EntityStructInitializer BuildEntity<T>(int entityID, ExclusiveGroup groupID, object[] implementors) where T : IEntityDescriptor, new()
            {
                return _weakEngine.Target.BuildEntity<T>(new EGID(entityID, (int)groupID), implementors);
            }

            public EntityStructInitializer BuildEntity<T>(EGID egid, object[] implementors) where T : IEntityDescriptor, new()
            {
                return _weakEngine.Target.BuildEntity<T>(egid, implementors);
            }

            public EntityStructInitializer BuildEntity(int entityID, IEntityDescriptor descriptorEntity, object[] implementors)
            {
                return _weakEngine.Target.BuildEntity(new EGID(entityID), descriptorEntity, implementors);
            }

            public EntityStructInitializer BuildEntity(EGID egid, IEntityDescriptor descriptorEntity, object[] implementors)
            {
                return _weakEngine.Target.BuildEntity(egid, descriptorEntity, implementors);
            }

            public EntityStructInitializer BuildEntity(int entityID, ExclusiveGroup groupID, IEntityDescriptor descriptorEntity, object[] implementors)
            {
                return _weakEngine.Target.BuildEntity(new EGID(entityID, (int)groupID), descriptorEntity, implementors);
            }
            
            public void PreallocateEntitySpace<T>(int size) where T : IEntityDescriptor, new()
            {
                _weakEngine.Target.Preallocate<T>(ExclusiveGroup.StandardEntitiesGroup, size);
            }
            
            public void PreallocateEntitySpace<T>(ExclusiveGroup groupID, int size) where T : IEntityDescriptor, new()
            {
                _weakEngine.Target.Preallocate<T>((int)groupID, size);
            }
        }
    }
}